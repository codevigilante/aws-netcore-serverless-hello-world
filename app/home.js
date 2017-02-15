function resolveTemplate(id, placeholder)
{
    var templateHtml = $(id).html();
    var template = Handlebars.compile(templateHtml);

    var context =
    {
        "title": "Hello World"
    };

    var compiledHtml = template(context);

    $(placeholder).html(compiledHtml);

    console.log(compiledHtml);
}

$(document).ready(function()
{
    resolveTemplate("#data", ".data-container");
});