chat = chat || {};

chat.PollingService = function (url, cb) {
    var self = this;

    function _poll() {
        chat.AjaxService.getJSON(url, {id: "trr"})
        .done(cb)
        .fail(function () {

        })
        .always(_poll);
    }

    _poll();
    
};