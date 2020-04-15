// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","./ImmutableArray","./languageUtils","../geometry/Geometry"],function(m,n,k,e,l){function f(d){var a=null;if(null!==d)if(e.isNumber(d))a=e.toNumber(d);else if(e.isBoolean(d))a=e.toBoolean(d);else if(e.isString(d))a=e.toString(d);else if(e.isDate(d))a=e.toDate(d);else if(e.isArray(d))for(var a=[],b=0;b<d.length;b++)a.push(f(d[b]));else{if(0===Object.keys(d).length)return null;a=new g;a.immutable=!1;for(var b=0,c=Object.keys(d);b<c.length;b++){var h=c[b];a.setField(h,f(d[h]))}a.immutable=
!0}return a}var g=function(){function d(a){this.declaredClass="esri.arcade.Dictionary";this.attributes=null;this.plain=!1;this.immutable=!0;this.attributes=a instanceof d?a.attributes:void 0===a?{}:null===a?{}:a}d.prototype.field=function(a){var b=a.toLowerCase();a=this.attributes[a];if(void 0!==a)return a;for(var c in this.attributes)if(c.toLowerCase()===b)return this.attributes[c];throw Error("Field not Found");};d.prototype.setField=function(a,b){if(this.immutable)throw Error("Dictionary is Immutable");
var c=a.toLowerCase();if(void 0===this.attributes[a])for(var d in this.attributes)if(d.toLowerCase()===c){this.attributes[d]=b;return}this.attributes[a]=b};d.prototype.hasField=function(a){var b=a.toLowerCase();if(void 0!==this.attributes[a])return!0;for(var c in this.attributes)if(c.toLowerCase()===b)return!0;return!1};d.prototype.keys=function(){var a=[],b;for(b in this.attributes)a.push(b);return a=a.sort()};d.prototype.castToText=function(){var a="",b;for(b in this.attributes){""!==a&&(a+=",");
var c=this.attributes[b];null==c?a+=JSON.stringify(b)+":null":e.isBoolean(c)||e.isNumber(c)||e.isString(c)?a+=JSON.stringify(b)+":"+JSON.stringify(c):c instanceof l?a+=JSON.stringify(b)+":"+e.toStringExplicit(c):c instanceof k?a+=JSON.stringify(b)+":"+e.toStringExplicit(c):c instanceof Array?a+=JSON.stringify(b)+":"+e.toStringExplicit(c):c instanceof Date?a+=JSON.stringify(b)+":"+JSON.stringify(c):null!==c&&"object"===typeof c&&void 0!==c.castToText&&(a+=JSON.stringify(b)+":"+c.castToText())}return"{"+
a+"}"};d.convertObjectToArcadeDictionary=function(a){var b=new d;b.immutable=!1;for(var c in a)b.setField(c.toString(),f(a[c]));b.immutable=!0;return b};return d}();return g});