chat = chat || {};

chat.PollingService = function (url, cb) {
    var self = this;

    function _poll() {
      chat.AjaxService.getJSON(url)
        .done(cb)
        .fail(function () {

        })
        .always(setTimeout(_poll, 5000));
    }

    _poll();
    
};