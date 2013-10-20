var chat = chat || {};

chat.AjaxService = {
    getJSON: function (url, data) {
        return $.getJSON(url, data);
    },
    postJSON: function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: data
        });
    }
};