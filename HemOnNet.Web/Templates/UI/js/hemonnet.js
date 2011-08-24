var HemOnNet = function () {
	var regularScrollableAPI = null,
		scrollableAPI = null,
		selectedHighlightNavLink = null,
		smallScrollableAPI = null,
	
	init = function () {
		// Setting body height for background to fill it all
		$("#container").css("min-height", $(window).height() - 40);
		

		// Lazy loading of images
		$(".main-text-content img, .article-media-content img, .foot img").lazyload();

		// Toggle search site field
		var searchSiteForm = $(".search-site .search-site-form");
		searchSiteForm.click(function(evt) {
		    evt.stopPropagation();
		});
		$("#search-site").click(function(evt) {
		    searchSiteForm.toggle();
		    evt.stopPropagation();
		});
		$("body").click(function() {
		    searchSiteForm.hide();
		});

		// Tab navigation
		tabNavigation();

		// Toogle tab navigation content
		$("ul.toggle-content").click(function(evt) {
		    $(this).next(".tab-nav-content").toggle();
		    $(this).toggleClass("expanded");
		    return false;
		});
		
		
		// Carousel with navigation buttons
		carousels();
		
		// ColorBox/Lightbox
		colorBox();
		
		// Slideshow effect
		slideshow();				
		
		// Elastic textareas when typing
		if ($.fn.elastic) {
			$("textarea").elastic();
		}
		
		
		
		// Print document
		$("a.print").click(function () {
			window.print();
			return false;
		});
	},
	
	
	carousels = function () {
		if ($.fn.scrollable) {
			// Regular scrollable
			regularScrollableAPI = $(".scrollable:not(.carousel-two-size-list)").scrollable({
				size : 1,
				clickable : false,
				api : true
			});
			if (regularScrollableAPI) {
				regularScrollableAPI.getRoot().navigator();
				if (regularScrollableAPI.getPageAmount() === 1) {
					regularScrollableAPI.getNaviButtons().css("visibility", "hidden");
				}
			}
			
			// Two-size scrollable
			twoSizeScrollableAPI = $(".scrollable.carousel-two-size-list").scrollable({
				size : 2,
				clickable : false,
				api : true
			});
			if (twoSizeScrollableAPI) {
				twoSizeScrollableAPI.getRoot().navigator();
				if (twoSizeScrollableAPI.getPageAmount() === 1) {
					twoSizeScrollableAPI.getNaviButtons().css("visibility", "hidden");
				}
			}
			
			// Small scrollable
			var smallScrollableAPI = $(".scrollable-small").scrollable({
				size : 1,
				clickable : false,
				api : true
			}),
				itemHeight,
				highestItem = 200;
			if (smallScrollableAPI) {
				smallScrollableAPI.getRoot().navigator();
				
				smallScrollableAPI.getItems().each(function () {
					itemHeight = $(this).outerHeight();
					if (itemHeight > highestItem) {
						highestItem = itemHeight;
					}
				});
				smallScrollableAPI.getItemWrap().parent().css("height", highestItem);
				if (smallScrollableAPI.getPageAmount() === 1) {
					smallScrollableAPI.getNaviButtons().css("visibility", "hidden");
				}
			}
		}
	},

	tabNavigation = function() {
	    $(".tabs").click(function(evt) {
	        var current = $(evt.target),
				tabs = current.parents(".tabs").find("li"),
				index = current.parent().prevAll().length,
				tabContent = current.parents(".tab-navigation").find(".tab-content-area");

	        tabs.removeClass("current");
	        tabContent.removeClass("current");
	        $(tabs[index]).addClass("current");
	        $(tabContent[index]).addClass("current");
	        return false;
	    });
	},
	
	colorBox = function () {
		if ($.fn.colorbox) {
			// Applies ColorBox event to all applicable links
			$("a[rel='lightbox']").each(function () {
				$(this).colorbox({
					slideshow : true,
					slideshowAuto : false,
					opacity : "0.7",
					title : $(this).parent().find("p.description").html(),
					slideshowStart : "Starta bildspel",
					slideshowStop : "Stoppa bildspel",
					slideshowSpeed : 5000,
					current : "Bild {current} av {total}",
					previous : "Föregående",
					next : "Nästa",
					close : "Stäng",
					maxWidth : "90%",
					maxHeight : "90%",
					scalePhotos : true,
					photo : true, // Needed for streamed images
					onLoad : function () {
						$("#cboxTitle").hide();
					},
					onComplete : function () {
						$("#cboxTitle").show();
					}
				}
			);
			});
			
			// Applies ColorBox event to all applicable links
			$("a[rel='lightbox-video']").each(function () {
				$(this).colorbox({
					slideshow : true,
					slideshowAuto : false,
					opacity : "0.7",
					title : $(this).parent().find("p.description").html(),
					slideshowStart : "Starta bildspel",
					slideshowStop : "Stoppa bildspel",
					slideshowSpeed : 5000,
					current : "Video {current} av {total}",
					previous : "Föregående",
					next : "Nästa",
					close : "Stäng",
					maxWidth : "90%",
					maxHeight : "90%",
					scalePhotos : true,
					onLoad : function () {
						$("#cboxTitle").hide();
					},
					onComplete : function () {
						$("#cboxTitle").show();
					}
				}
			);
			});
		}
	},
	
	slideshow = function () {
		if ($.fn.cycle) {
			$(".page-main-image").cycle({ 
			    speed : 1000, 
			    timeout : 7000,
				cleartype : true,
			    pager : ".main-image-nav"
			});
			
			$(".main-image-nav-pause").click(function () {
				$(".page-main-image").cycle("pause");
				$(this).hide();
				$(".main-image-nav-play").show();
			});
			
			$(".main-image-nav-play").click(function () {
				$(".page-main-image").cycle("resume");
				$(this).hide();
				$(".main-image-nav-pause").show();
			});
		}
	};
	return {
		init : init
	};
}();
$(document).ready(function () {
    HemOnNet.init();
});
