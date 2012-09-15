var QuickWinScripts = {
    init: function() {
        this.setupGalleries();
    },
    setupGalleries: function () {
        $('div.nivo').nivoGallery();
    }
};

$(function() {
    QuickWinScripts.init();
});