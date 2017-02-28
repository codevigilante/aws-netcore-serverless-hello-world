function resolveTemplate(id, placeholder, context)
{
    var templateHtml = $(id).html();
    var template = Handlebars.compile(templateHtml);

    var compiledHtml = template(context);

    $(placeholder).html(compiledHtml);
}

$(document).ready(function()
{
    $.ajax(
    {
        url: "https://ugleus55fg.execute-api.us-east-1.amazonaws.com/test/greetings",
        success: function(result)
        {
            console.log(result);
                        
            resolveTemplate("#data", ".data-container", result);
        },
        error: function()
        {
            alert("There was an error fetching the greeting from the API.");
        },
        method: 'GET',
        cache: false,
        dataType: 'json'
    });
});