var layersCms = layersCms || {};

// Tooltips
layersCms.initTooltips = function () {
    $('a.tip, .tips a').tipsy({ fade: true, gravity: 'n', opacity: 0.85 });
    $('i.help-tip').tipsy({ fade: true, gravity: 'sw', opacity: 0.85 });
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

// Bootstrap validation styles with MVC jQuery validation
$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest(".control-group").addClass("error");
    },
    unhighlight: function (element) {
        console.log(element);
        $(element).closest(".control-group").removeClass("error");
    }
});

layersCms.initBootstrapValidationStyles = function() {
    $('form .input-validation-error').closest(".control-group").addClass("error");
};










// Function to manage all page-ready initialisation

layersCms.init = function() {
    layersCms.initTooltips();
    layersCms.initPagePreviews();
    layersCms.initDateAndTimeControls();
    layersCms.initBootstrapValidationStyles();
};







// DOM-ready initialise
$(function() {
    layersCms.init();
});