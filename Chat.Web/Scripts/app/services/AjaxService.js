var chat = chat || {};

chat.AjaxService = function(){
    var self = this;

    self.getJSON = function (url, data) {
        return $.getJSON(url, data);
    };

    self.postJSON = function (url, data) {
        if (data !== null && typeof data === 'object')
            data = ko.mapping.toJSON(data);

        return $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: data
        });
    };
};