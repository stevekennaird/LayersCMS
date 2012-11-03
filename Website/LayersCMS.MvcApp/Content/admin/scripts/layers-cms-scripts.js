var layersCms = layersCms || {};

// Tooltips
layersCms.initTooltips = function () {
    $('a.tip, .tips a').tipsy({ fade: true, gravity: 'n' });
};

// Page preview lightboxes
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

// Datepickers
layersCms.initDateAndTimeControls = function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        weekStart: 1,
        autoclose: true
    });
    $('.timepicker-default').timepicker({
        defaultTime: '00:00',
        showMeridian: false,
        showInputs: false,
        minuteStep: 5
    });
};












// Function to manage all page-ready initialisation

layersCms.init = function() {
    layersCms.initTooltips();
    layersCms.initPagePreviews();
    layersCms.initDateAndTimeControls();
};







// DOM-ready initialise
$(function() {
    layersCms.init();
});