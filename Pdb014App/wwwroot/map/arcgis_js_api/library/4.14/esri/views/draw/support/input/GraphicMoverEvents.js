// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports"],function(a,b){Object.defineProperty(b,"__esModule",{value:!0});a=function(){return function(f,a,c,d,e){this.graphic=f;this.index=a;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-click"}}();b.GraphicClickEvent=a;a=function(){return function(a,m,c,d,e){this.graphic=a;this.index=m;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-double-click"}}();b.GraphicDoubleClickEvent=a;a=function(){function a(a,c,d,e,f,b,g,h,k,l){this.graphic=a;this.allGraphics=c;this.index=
d;this.x=e;this.y=f;this.dx=b;this.dy=g;this.totalDx=h;this.totalDy=k;this.viewEvent=l;this.defaultPrevented=!1;this.type="graphic-move-start"}a.prototype.preventDefault=function(){this.defaultPrevented=!0};return a}();b.GraphicMoveStartEvent=a;a=function(){function a(a,c,d,e,f,b,g,h,k,l){this.graphic=a;this.allGraphics=c;this.index=d;this.x=e;this.y=f;this.dx=b;this.dy=g;this.totalDx=h;this.totalDy=k;this.viewEvent=l;this.defaultPrevented=!1;this.type="graphic-move"}a.prototype.preventDefault=function(){this.defaultPrevented=
!0};return a}();b.GraphicMoveEvent=a;a=function(){function a(a,c,d,e,b,f,g,h,k,l){this.graphic=a;this.allGraphics=c;this.index=d;this.x=e;this.y=b;this.dx=f;this.dy=g;this.totalDx=h;this.totalDy=k;this.viewEvent=l;this.defaultPrevented=!1;this.type="graphic-move-stop"}a.prototype.preventDefault=function(){this.defaultPrevented=!0};return a}();b.GraphicMoveStopEvent=a;a=function(){return function(a,b,c,d,e){this.graphic=a;this.index=b;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-pointer-over"}}();
b.GraphicPointerOverEvent=a;a=function(){return function(a,b,c,d,e){this.graphic=a;this.index=b;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-pointer-out"}}();b.GraphicPointerOutEvent=a;a=function(){return function(a,b,c,d,e){this.graphic=a;this.index=b;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-pointer-down"}}();b.GraphicPointerDownEvent=a;a=function(){return function(a,b,c,d,e){this.graphic=a;this.index=b;this.x=c;this.y=d;this.viewEvent=e;this.type="graphic-pointer-up"}}();b.GraphicPointerUpEvent=
a});