// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports"],function(g,h){Object.defineProperty(h,"__esModule",{value:!0});g=function(){function e(d){this._totalCount=d;this._indexRanges=[0,d]}e.prototype.componentCount=function(){for(var d=this._indexRanges,b=0,a=0;a<d.length;a+=2)b+=d[a+1];return b};e.prototype.reset=function(d){if("all"===d||d.length===this._totalCount)this._indexRanges=[0,this._totalCount];else{var b=[];if(0!==d.length){for(var a=d[0],c=1,f=1;f<d.length;f++){var e=d[f];a+c===e?c+=1:(b.push(a),b.push(c),a=e,
c=1)}b.push(a);b.push(c)}this._indexRanges=b}};e.prototype.forEachComponent=function(d){for(var b=this._indexRanges,a=0;a<b.length;a+=2)for(var c=b[a],f=c+b[a+1];c<f;c++)if(!d(c))return!1;return!0};e.prototype.forEachComponentRange=function(d){for(var b=this._indexRanges,a=0;a<b.length;a+=2){var c=b[a];if(!d(c,c+b[a+1]))return!1}return!0};e.prototype.computeOffsetRanges=function(d){for(var b=Array(this._indexRanges.length),a=this._indexRanges,c=0;c<a.length;c+=2){var f=a[c],e=d[f],f=d[f+a[c+1]];b[c]=
e;b[c+1]=f-e}return b};return e}();h.ComponentRangeRunLengthEncoded=g});