// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","./Callout3D","./LineCallout3D"],function(g,b,f,d){function c(a){if(!a)return!1;a=a.verticalOffset;return!a||0>=a.screenLength||0>=a.maxWorldLength?!1:!0}function e(a,b,c){if(!a)return a;switch(a.type){case "line":return b=new d,b.read(a,c),b}}Object.defineProperty(b,"__esModule",{value:!0});b.hasVisibleVerticalOffset=c;b.hasVisibleCallout=function(a){if(!a||!a.supportsCallout||!a.supportsCallout())return!1;var b=a.callout;return b&&b.visible?c(a)?!0:!1:!1};b.isCalloutSupport=
function(a){return"point-3d"===a.type||"label-3d"===a.type};b.read=e;b.calloutProperty={types:{key:"type",base:f,typeMap:{line:d}},json:{read:e,write:!0}}});