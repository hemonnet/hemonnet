(function () {
	var elms = [
		"article",
		"aside",
		"nav",
		"section",
		"hgroup",
		"header",
		"footer",
		"figure",
		"time"
	];
	for (var i=0, il=elms.length; i<il; i++) {
		document.createElement(elms[i]);
	};	
})();