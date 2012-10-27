var layersCms = layersCms || {};

// Tooltips
layersCms.initTooltips = function () {
    $('a.tip, .tips a').tipsy({ fade: true, gravity: 'n' });
};

layersCms.initPagePreviews = function() {
    $('a.page-preview').fancybox({
        width: 1100,
        minHeight: 500,
        title: function () {
            return '<em>Page Preview:</em> ' + $(this).attr('data-page-title');
        }
    });

    $('a.fancybox').fancybox();
};













// Function to manage all page-ready initialisation

layersCms.init = function() {
    layersCms.initTooltips();
    layersCms.initPagePreviews();
};







// DOM-ready initialise
$(function() {
    layersCms.init();
});