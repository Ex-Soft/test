import Handlebars from "handlebars";

let str ="<a href=\"{{url}}\">\
    {{~#if test}}\
      {{~title}}\
    {{~^~}}\
      Empty\
    {{~/if~}}\
  </a>\
";

let template = Handlebars.compile(str);
let result = template({ url: "https://google.com/", test: true, title: "google.com" });
console.log(result);
result = template({ url: "https://google.com/", test: false, title: "google.com" });
console.log(result);

str ="<a href=\"{{url}}\">\
    {{#if test}}\
      {{title}}\
    {{^}}\
      Empty\
    {{/if}}\
  </a>\
";

template = Handlebars.compile(str);
result = template({ url: "https://google.com/", test: true, title: "google.com" });
console.log(result);
result = template({ url: "https://google.com/", test: false, title: "google.com" });
console.log(result);

str = "\
<p>{{#if is60days}}We're reaching out to let you know{{else}}This is a friendly reminder{{/if}} that your DIRECTV microsite subscription {{#if is3days}}will{{else}}is scheduled to{{/if}} expire in {{days}} days.{{#if is3days}} This is your final notice.{{/if}}</p>\
<p>To keep your DIRECTV microsite live, you will need to renew in the program within the next {{days}} days.</p>\
<p>Renewal is easy! {{#if is3days}}To renew, p{{else}}P{{/if}}lease click the link below to renew your microsite with either a one-year or two-year subscription option.</p>\
<p><a href=\"{{productUrl}}\">View product</a></p>\
";

template = Handlebars.compile(str);
result = template({ days: 60, productUrl: "https://google.com/", is60days: true, is3days: false });
console.log(result);
result = template({ days: 30, productUrl: "https://google.com/", is60days: false, is3days: false });
console.log(result);
result = template({ days: 14, productUrl: "https://google.com/", is60days: false, is3days: false });
console.log(result);
result = template({ days: 3, productUrl: "https://google.com/", is60days: false, is3days: true });
console.log(result);