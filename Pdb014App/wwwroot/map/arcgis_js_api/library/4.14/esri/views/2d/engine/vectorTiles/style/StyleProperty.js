// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../Color","../GeometryUtils"],function(n,p,k,l){return function(){function d(a,b){this.isDataDriven=!1;var c;switch(a.type){case "number":c=!0;break;case "color":c=!0;b=d._parseColor(b);break;case "array":c="number"===a.value;break;default:c=!1}null==b&&(b=a.default);c&&"interval"===b.type&&(c=!1);var f=b&&b.stops&&0<b.stops.length;if(f)for(var e=0,g=b.stops;e<g.length;e++){var m=g[e];m[1]=this._validate(m[1],a)}if(this.isDataDriven=b?!!b.property:!1)if(void 0!==
b.default&&(b.default=this._validate(b.default,a)),f)switch(b.type){case "identity":this.getValue=this._buildIdentity(b,a);break;case "categorical":this.getValue=this._buildCategorical(b,a);break;default:this.getValue=c?this._buildInterpolate(b,a):this._buildInterval(b,a)}else this.getValue=this._buildIdentity(b,a);else f?this.getValue=c?this._buildZoomInterpolate(b):this._buildZoomInterval(b):(b=this._validate(b,a),this.getValue=this._buildSimple(b))}d.prototype._validate=function(a,b){if("number"===
b.type){if(a<b.minimum)return b.minimum;if(a>b.maximum)return b.maximum}return a};d.prototype._buildSimple=function(a){return function(){return a}};d.prototype._buildIdentity=function(a,b){var c=this;return function(f,e){var g;e&&(g=e.values[a.property],"color"===b.type&&(g=d._parseColor(g)));void 0===g&&(g=a.default);return void 0!==g?c._validate(g,b):b.default}};d.prototype._buildCategorical=function(a,b){var c=this;return function(f,e){var g;e&&(g=e.values[a.property]);g=c._categorical(g,a.stops);
return void 0!==g?g:void 0!==a.default?a.default:b.default}};d.prototype._buildInterval=function(a,b){var c=this;return function(f,e){var g;e&&(g=e.values[a.property]);return"number"===typeof g?c._interval(g,a.stops):void 0!==a.default?a.default:b.default}};d.prototype._buildInterpolate=function(a,b){var c=this;return function(f,e){var g;e&&(g=e.values[a.property]);return"number"===typeof g?c._interpolate(g,a.stops,a.base||1):void 0!==a.default?a.default:b.default}};d.prototype._buildZoomInterpolate=
function(a){var b=this;return function(c){return b._interpolate(c,a.stops,a.base||1)}};d.prototype._buildZoomInterval=function(a){var b=this;return function(c){return b._interval(c,a.stops)}};d.prototype._categorical=function(a,b){for(var c=b.length,f=0;f<c;f++)if(b[f][0]===a)return b[f][1]};d.prototype._interval=function(a,b){for(var c=b.length,f=0,e=0;e<c;e++)if(b[e][0]<=a)f=e;else break;return b[f][1]};d.prototype._interpolate=function(a,b,c){for(var f,e,g=b.length,d=0;d<g;d++){var h=b[d];if(h[0]<=
a)f=h;else{e=h;break}}if(f&&e){d=e[0]-f[0];a-=f[0];c=1===c?a/d:(Math.pow(c,a)-1)/(Math.pow(c,d)-1);if(Array.isArray(f[1])){f=f[1];e=e[1];a=[];for(d=0;d<f.length;d++)a.push(l.interpolate(f[d],e[d],c));return a}return l.interpolate(f[1],e[1],c)}if(f)return f[1];if(e)return e[1]};d._isEmpty=function(a){for(var b in a)if(a.hasOwnProperty(b))return!1;return!0};d._parseColor=function(a){if(Array.isArray(a))return a;if("string"===typeof a){if(a=new k(a),!this._isEmpty(a))return k.toUnitRGBA(a)}else return a&&
a.default&&(a.default=d._parseColor(a.default)),a&&a.stops&&(a.stops=a.stops.map(function(a){return[a[0],d._parseColor(a[1])]})),a};return d}()});