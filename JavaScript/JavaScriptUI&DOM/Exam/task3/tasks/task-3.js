function solve() {
    return function (selector) {
        var template = '' +
            '<div class="events-calendar">'+
            '<h2 class="header">'+
               ' Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>'+
    '</h2>'+
   ' {{#each days}}'+
'<div class="col-date">'+
   '<div class="date">{{day}}</div>'+
'{{#each this.events}}'+
'<div class="events">'+
    '<div class="event {{importance}}" {{#if this.comment}}title="{{this.comment}}"{{/if}}>'+
'<div class="title">{{#if title}}{{{title}}}{{else}}Free slot{{/if}}</div>'+
'{{#if time}}'+
'<span class="time">at: {{time}}</span>'+
    '{{/if}}'+
'</div>'+
    '</div>'+
    '{{/each}}'+
'</div>'+
'{{/each}}'
            ;
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;