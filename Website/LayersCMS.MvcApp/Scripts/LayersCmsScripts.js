var LayersCmsScripts = {
    init: function() {
        this.setupGalleries();
    },
    setupGalleries: function () {
        $('div.nivo').nivoGallery();
    }
};

$(function() {
    LayersCmsScripts.init();
});