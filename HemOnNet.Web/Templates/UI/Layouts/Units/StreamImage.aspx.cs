using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemOnNet.Core.Drawing;

namespace N2.Templates.UI.Layouts.Units
{
    public partial class StreamImage : Page
    {

        #region FileToStream Interface
        public interface FileToStream
        {
            #region Properties
            string Name { get; }
            string MimeType { get; }
            bool Exists { get; }
            DateTime LastModified { get; }
            #endregion

            #region Methods
            Stream OpenStream();
            #endregion
        }
        #endregion

        #region Default FileToStream Implementation
        private class FileToStreamImpl : FileToStream
        {
            #region Members
            private VirtualFile m_VirtualFile;
            private FileInfo m_FileInfo;
            #endregion

            #region Properties
            private string Extension { get { return Path.GetExtension(this.Name); } }
            public string Name { get { return m_FileInfo != null ? m_FileInfo.Name : (m_VirtualFile != null ? m_VirtualFile.Name : null); } }
            public string MimeType { get { return "image/" + this.Extension.Substring(1); } }
            public bool Exists { get { return m_FileInfo != null ? m_FileInfo.Exists : m_VirtualFile != null; } }

            public DateTime LastModified
            {
                get
                {
                    if (m_FileInfo != null)
                    {
                        return m_FileInfo.LastAccessTimeUtc;
                    }
                    else
                    {
                        DateTime dateNow = DateTime.Now;
                        return new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, 0, 0);
                    }
                }
            }
            #endregion

            #region Constructors
            public FileToStreamImpl(string path)
            {
                path = HttpUtility.UrlDecode(path);
                string filePath = HttpContext.Current.Server.MapPath(path);
                if (File.Exists(filePath))
                {
                    m_FileInfo = new FileInfo(filePath);
                }
                else if (HostingEnvironment.VirtualPathProvider.FileExists(path))
                {
                    m_VirtualFile = HostingEnvironment.VirtualPathProvider.GetFile(path);
                }
            }
            #endregion

            #region Methods
            public Stream OpenStream()
            {
                if (m_FileInfo != null)
                {
                    return m_FileInfo.OpenRead();
                }
                else
                {
                    return m_VirtualFile.Open();
                }
            }
            #endregion
        }
        #endregion

        #region Methods
        public virtual FileToStream GetFileToStream(string path)
        {

            FileToStream file = null;
            try
            {
                file = new FileToStreamImpl(path); //GetFileToStreamInternal(path);
            }
            catch (FileNotFoundException) { }
            if (file == null)
                file = new FileToStreamImpl(path);
            return file;
        }

        #endregion

        #region Overridden Methods
        protected override void OnLoad(EventArgs e)
        {
            // See if client has a cached version of the image
            string ifModifiedSince = this.Request.Headers.Get("If-Modified-Since");

            string reqPath = this.Request.QueryString["path"];
            string path = reqPath != null ? reqPath : string.Empty;

            FileToStream fileToStream = this.GetFileToStream(path);
            if (fileToStream.Exists)
            {
                //Get the last modified time for the current file
                //Handle the situation where we get a LastModified that is in the future
                DateTime now = DateTime.Now;
                DateTime lastModifiedTime = fileToStream.LastModified > now ? now : fileToStream.LastModified;

                //Check to see if it is a conditional HTTP GET.
                if (ifModifiedSince != null)
                {
                    //This is a conditional HTTP GET request. Compare the strings.
                    try
                    {
                        DateTime incrementalIndexTime = DateTime.Parse(ifModifiedSince, DateTimeFormatInfo.InvariantInfo).ToUniversalTime();
                        // Has to do a string compare because of the resolution
                        if (incrementalIndexTime.ToString(DateTimeFormatInfo.InvariantInfo) ==
                            lastModifiedTime.ToString(DateTimeFormatInfo.InvariantInfo))
                        {
                            // If the file has not been modifed, send a not changed status
                            this.Response.StatusCode = 304;
                            this.Response.End();
                        }
                    }
                    catch (FormatException)
                    {
                    }
                }

                string reqWidth = Page.Request.QueryString["width"];
                string reqHeight = Page.Request.QueryString["height"];
                string reqAllowEnlarging = Page.Request.QueryString["allowEnlarging"];
                string reqAllowStretching = Page.Request.QueryString["allowStretching"];

                int width = 0;
                int height = 0;
                bool allowEnlarging = reqAllowEnlarging != null && string.Compare(reqAllowEnlarging, "true", true, CultureInfo.InvariantCulture) == 0;
                bool allowStretching = reqAllowStretching != null && string.Compare(reqAllowStretching, "true", true, CultureInfo.InvariantCulture) == 0;

                try
                {
                    width = reqWidth == null ? width : int.Parse(reqWidth, NumberFormatInfo.InvariantInfo);
                }
                catch (FormatException) { }
                try
                {
                    height = reqHeight == null ? height : int.Parse(reqHeight, NumberFormatInfo.InvariantInfo);
                }
                catch (FormatException) { }

                using (Stream fileStream = fileToStream.OpenStream())
                {
                    ImageScale.ResizeFlags resizeFlags = ImageScale.ResizeFlags.None;
                    if (allowEnlarging)
                    {
                        resizeFlags = resizeFlags | ImageScale.ResizeFlags.AllowEnlarging;
                    }
                    if (allowStretching)
                    {
                        resizeFlags = resizeFlags | ImageScale.ResizeFlags.AllowStretching;
                    }

                    this.Response.Clear();
                    try
                    {
                        ImageScale.Resize(fileStream, this.Response.OutputStream, width, height, resizeFlags);
                        this.Response.AddHeader("Content-Disposition", "inline;filename=\"" + fileToStream.Name + "\"");
                        this.Response.ContentType = fileToStream.MimeType;
                        this.Response.Cache.SetLastModified(lastModifiedTime);
                        //The following lines enable downlevel caching in server or browser cache. But not in proxies.
                        this.Response.Cache.SetCacheability(HttpCacheability.Public);
                        //Set the expiration time for the downlevel cache
                        this.Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
                        this.Response.Cache.SetValidUntilExpires(true);
                        this.Response.Cache.VaryByParams["*"] = true;
                    }
                    catch (OutOfMemoryException ex)
                    {
                        // If not image
                        throw new FileNotFoundException(ex.Message, ex);
                    }
                    catch (FileNotFoundException)
                    {
                        // If file not found
                        // We know that the file exists so we throw a forbidden request exception
                        throw new HttpException(403, "Forbidden");
                    }
                }
            }
            else
            {
                this.Response.Clear();
                throw new HttpException(404, "Not Found");
            }
        }
        #endregion
    }
}
