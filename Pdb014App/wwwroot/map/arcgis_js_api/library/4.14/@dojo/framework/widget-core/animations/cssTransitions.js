//>>built
(function(b){"object"===typeof module&&"object"===typeof module.exports?(b=b(require,exports),void 0!==b&&(module.exports=b)):"function"===typeof define&&define.amd&&define(["require","exports"],b)})(function(b,h){function l(a){if("WebkitTransition"in a.style)g="webkitTransitionEnd",f="webkitAnimationEnd";else if("transition"in a.style||"MozTransition"in a.style)g="transitionend",f="animationend";else throw Error("Your browser is not supported");}function k(a,b,c){""===f&&l(a);var d=!1,e=function(){d||
(d=!0,a.removeEventListener(g,e),a.removeEventListener(f,e),c())};b();a.addEventListener(f,e);a.addEventListener(g,e)}Object.defineProperty(h,"__esModule",{value:!0});var g="",f="";h.default={enter:function(a,b,c){var d=b.enterAnimationActive||c+"-active";k(a,function(){a.classList.add(c);requestAnimationFrame(function(){a.classList.add(d)})},function(){a.classList.remove(c);a.classList.remove(d)})},exit:function(a,b,c,d){var e=b.exitAnimationActive||c+"-active";k(a,function(){a.classList.add(c);
requestAnimationFrame(function(){a.classList.add(e)})},function(){d()})}}});