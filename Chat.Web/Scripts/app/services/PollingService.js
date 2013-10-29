chat = chat || {};

chat.PollingService = function (ajaxService, url, name, cb) {
    var self = this;

    self.poll = function() {
        ajaxService.getJSON(url, {name: name})
        .done(cb)
        .fail(function () {

        })
        .always(self.poll);
    }

};