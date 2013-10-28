chat = chat || {};

chat.PollingService = function (ajaxService, url, cb) {
    var self = this;

    self.poll = function() {
        ajaxService.getJSON(url)
        .done(cb)
        .fail(function () {

        })
        .always(self.poll);
    }

};