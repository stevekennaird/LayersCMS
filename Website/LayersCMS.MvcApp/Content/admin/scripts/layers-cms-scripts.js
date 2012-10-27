var layersCms = layersCms || {};

// Tooltips
layersCms.initTooltips = function () {
    $('a.tip, .tips a').tipsy({ fade: true, gravity: 'n' });
};















// Function to manage all page-ready initialisation

layersCms.init = function() {
    layersCms.initTooltips();
};







// DOM-ready initialise
$(function() {
    layersCms.init();
});