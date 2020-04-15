// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../ArcadePortal ../Dictionary ../Dictionary ../Feature ../featureSetCollection ../featureSetUtils ../languageUtils ../featureset/actions/Adapted ../featureset/actions/AttributeFilter ../featureset/actions/OrderBy ../featureset/actions/Top ../featureset/sources/Empty ../featureset/sources/FeatureLayerMemory ../featureset/support/OrderbyClause ../featureset/support/shared ../featureset/support/sqlUtils ./fieldStats ../../core/promiseUtils ../../core/sql/WhereClause ../../layers/FeatureLayer ../../layers/support/Field".split(" "),
function(W,G,N,H,z,w,I,t,c,q,J,O,P,Q,R,S,T,K,C,u,x,D,U){function V(b,k,d,l){if(1===l.length){if(c.isArray(l[0]))return C.calculateStat(b,l[0],-1);if(c.isImmutableArray(l[0]))return C.calculateStat(b,l[0].toArray(),-1)}return C.calculateStat(b,l,-1)}function E(b,c,d){var l=b.getVariables();if(0<l.length){for(var k=[],a=0;a<l.length;a++)k.push(c.evaluateIdentifier(d,{name:l[a]}));return u.all(k).then(function(a){for(var e={},c=0;c<l.length;c++)e[l[c]]=a[c];b.parameters=e;return b})}return u.resolve(b)}
function h(c,k,d){void 0===d&&(d=null);for(var l in c)if(l.toLowerCase()===k.toLowerCase())return c[l];return d}function L(c){if(null===c)return null;var b={type:h(c,"type",""),name:h(c,"name","")};if("range"===b.type)b.range=h(c,"range",[]);else{b.codedValues=[];var d=0;for(c=h(c,"codedValues",[]);d<c.length;d++){var l=c[d];b.codedValues.push({name:h(l,"name",""),code:h(l,"code",null)})}}return b}function F(c){if(null===c)return null;var b={},d=h(c,"wkt",null);null!==d&&(b.wkt=d);c=h(c,"wkid",null);
null!==c&&(b.wkid=c);return b}function M(c){if(null===c)return null;var b={hasZ:h(c,"hasz",!1),hasM:h(c,"hasm",!1)},d=h(c,"spatialreference",null);d&&(b.spatialReference=F(d));d=h(c,"x",null);if(null!==d)return b.x=d,b.y=h(c,"y",null),b;d=h(c,"rings",null);if(null!==d)return b.rings=d,b;d=h(c,"paths",null);if(null!==d)return b.paths=d,b;d=h(c,"points",null);if(null!==d)return b.points=d,b;for(var d=0,l="xmin xmax ymin ymax zmin zmax mmin mmax".split(" ");d<l.length;d++){var f=l[d],a=h(c,f,null);null!==
a&&(b[f]=a)}return b}Object.defineProperty(G,"__esModule",{value:!0});G.registerFunctions=function(b){"async"===b.mode&&(b.functions.featuresetbyid=function(k,d){return b.standardFunctionAsync(k,d,function(l,b,a){c.pcCheck(a,2,4);if(a[0]instanceof I){l=c.toString(a[1]);b=c.defaultUndefined(a[2],null);var e=c.toBoolean(c.defaultUndefined(a[3],!0));null===b&&(b=["*"]);if(!1===c.isArray(b))throw Error("Invalid Parameter");return a[0].featureSetById(l,e,b)}throw Error("Invalid Parameter");})},b.signatures.push({name:"featuresetbyid",
min:"2",max:"4"}),b.functions.featuresetbyportalitem=function(k,d){return b.standardFunctionAsync(k,d,function(b,f,a){c.pcCheck(a,2,5);if(null===a[0])throw Error("Portal is required");if(a[0]instanceof N){b=c.toString(a[1]);f=c.toString(a[2]);var e=c.defaultUndefined(a[3],null),l=c.toBoolean(c.defaultUndefined(a[4],!0));null===e&&(e=["*"]);if(!1===c.isArray(e))throw Error("Invalid Parameter");var m=null;k.services&&k.services.portal&&(m=k.services.portal);m=t.getPortal(a[0],m);return t.constructFeatureSetFromPortalItem(b,
f,k.spatialReference,e,l,m,k.lrucache)}if(!1===c.isString(a[0]))throw Error("Portal is required");b=c.toString(a[0]);f=c.toString(a[1]);e=c.defaultUndefined(a[2],null);a=c.toBoolean(c.defaultUndefined(a[3],!0));null===e&&(e=["*"]);if(!1===c.isArray(e))throw Error("Invalid Parameter");if(k.services&&k.services.portal)return t.constructFeatureSetFromPortalItem(b,f,k.spatialReference,e,a,k.services.portal,k.lrucache);throw Error("Portal is required");})},b.signatures.push({name:"featuresetbyportalitem",
min:"2",max:"5"}),b.functions.featuresetbyname=function(k,d){return b.standardFunctionAsync(k,d,function(b,f,a){c.pcCheck(a,2,4);if(a[0]instanceof I){b=c.toString(a[1]);f=c.defaultUndefined(a[2],null);var e=c.toBoolean(c.defaultUndefined(a[3],!0));null===f&&(f=["*"]);if(!1===c.isArray(f))throw Error("Invalid Parameter");return a[0].featureSetByName(b,e,f)}throw Error("Invalid Parameter");})},b.signatures.push({name:"featuresetbyname",min:"2",max:"4"}),b.functions.featureset=function(k,d){return b.standardFunction(k,
d,function(b,f,a){c.pcCheck(a,1,1);f=a[0];b={layerDefinition:{geometryType:"",objectIdField:"",typeIdField:"",fields:[]},featureSet:{geometryType:"",features:[]}};if(c.isString(f))f=JSON.parse(f),void 0!==f.layerDefinition?(b.layerDefinition=f.layerDefinition,b.featureSet=f.featureSet,f.layerDefinition.spatialReference&&(b.layerDefinition.spatialReference=f.layerDefinition.spatialReference)):(b.featureSet.features=f.features,b.featureSet.geometryType=f.geometryType,b.layerDefinition.geometryType=
b.featureSet.geometryType,b.layerDefinition.objectIdField=f.objectIdFieldName,b.layerDefinition.typeIdField=f.typeIdFieldName,b.layerDefinition.fields=f.fields,f.spatialReference&&(b.layerDefinition.spatialReference=f.spatialReference));else if(a[0]instanceof H){f=JSON.parse(a[0].castToText());var e=h(f,"layerdefinition");if(null!==e){b.layerDefinition.geometryType=h(e,"geometrytype","");b.featureSet.geometryType=b.layerDefinition.geometryType;b.layerDefinition.objectIdField=h(e,"objectidfield","");
b.layerDefinition.typeIdField=h(e,"typeidfield","");if(a=h(e,"spatialreference",null))b.layerDefinition.spatialReference=F(a);a=0;for(var d=h(e,"fields",[]);a<d.length;a++)e=d[a],e={name:h(e,"name",""),alias:h(e,"alias",""),type:h(e,"type",""),nullable:h(e,"nullable",!0),editable:h(e,"editable",!0),length:h(e,"length",null),domain:L(h(e,"domain"))},b.layerDefinition.fields.push(e);if(f=h(f,"featureset",null)){a={};e=0;for(d=b.layerDefinition.fields;e<d.length;e++){var m=d[e];a[m.name.toLowerCase()]=
m.name}for(var r=0,g=h(f,"features",[]);r<g.length;r++){f=g[r];e={};d=h(f,"attributes",{});for(m in d)e[a[m.toLowerCase()]]=d[m];b.featureSet.features.push({attributes:e,geometry:M(h(f,"geometry",null))})}}}else{b.layerDefinition.geometryType=h(f,"geometrytype","");b.featureSet.geometryType=b.layerDefinition.geometryType;b.layerDefinition.objectIdField=h(f,"objectidfieldname","");b.layerDefinition.typeIdField=h(f,"typeidfieldname","");if(a=h(f,"spatialreference",null))b.layerDefinition.spatialReference=
F(a);a=0;for(d=h(f,"fields",[]);a<d.length;a++)e=d[a],e={name:h(e,"name",""),alias:h(e,"alias",""),type:h(e,"type",""),nullable:h(e,"nullable",!0),editable:h(e,"editable",!0),length:h(e,"length",null),domain:L(h(e,"domain"))},b.layerDefinition.fields.push(e);a={};e=0;for(d=b.layerDefinition.fields;e<d.length;e++)m=d[e],a[m.name.toLowerCase()]=m.name;r=0;for(g=h(f,"features",[]);r<g.length;r++){f=g[r];e={};d=h(f,"attributes",{});for(m in d)e[a[m.toLowerCase()]]=d[m];b.featureSet.features.push({attributes:e,
geometry:M(h(f,"geometry",null))})}}}else throw Error("Invalid Parameter");if(b.layerDefinition&&b.featureSet){b:{m=0;for(f=" esriGeometryPoint esriGeometryPolyline esriGeometryPolygon esriGeometryMultipoint esriGeometryEnvelope".split(" ");m<f.length;m++)if(f[m]===b.layerDefinition.geometryType){m=!0;break b}m=!1}m=!1===m||null===b.layerDefinition.objectIdField||""===b.layerDefinition.objectIdField||!1===c.isArray(b.layerDefinition.fields)||!1===c.isArray(b.featureSet.features)?!1:!0}else m=!1;if(!1===
m)throw Error("Invalid Parameter");return R.create(b,k.spatialReference)})},b.signatures.push({name:"featureset",min:"1",max:"1"}),b.functions.filter=function(k,d){return b.standardFunctionAsync(k,d,function(d,f,a){c.pcCheck(a,2,2);return c.isFeatureSet(a[0])?a[0].load().then(function(c){var e=x.WhereClause.create(a[1],c.getFieldsIndex()),d=e.getVariables();if(0<d.length){c=[];for(var f=0;f<d.length;f++)c.push(b.evaluateIdentifier(k,{name:d[f]}));return u.all(c).then(function(b){for(var c={},g=0;g<
d.length;g++)c[d[g]]=b[g];e.parameters=c;return new J({parentfeatureset:a[0],whereclause:e})})}return u.resolve(new J({parentfeatureset:a[0],whereclause:e}))}):b.failDefferred("Filter cannot accept this parameter type")})},b.signatures.push({name:"filter",min:"2",max:"2"}),b.functions.orderby=function(k,d){return b.standardFunctionAsync(k,d,function(d,f,a){c.pcCheck(a,2,2);return c.isFeatureSet(a[0])?(d=new S(a[1]),u.resolve(new O({parentfeatureset:a[0],orderbyclause:d}))):b.failDefferred("Order cannot accept this parameter type")})},
b.signatures.push({name:"orderby",min:"2",max:"2"}),b.functions.top=function(k,d){return b.standardFunctionAsync(k,d,function(d,f,a){c.pcCheck(a,2,2);return c.isFeatureSet(a[0])?u.resolve(new P({parentfeatureset:a[0],topnum:a[1]})):c.isArray(a[0])?c.toNumber(a[1])>=a[0].length?a[0].slice(0):a[0].slice(0,c.toNumber(a[1])):c.isImmutableArray(a[0])?c.toNumber(a[1])>=a[0].length()?a[0].slice(0):a[0].slice(0,c.toNumber(a[1])):b.failDefferred("Top cannot accept this parameter type")})},b.signatures.push({name:"top",
min:"2",max:"2"}),b.functions.first=function(k,d){return b.standardFunctionAsync(k,d,function(b,d,a){c.pcCheck(a,1,1);return c.isFeatureSet(a[0])?a[0].first(b.abortSignal).then(function(b){if(null!==b){var c=w.createFromGraphicLikeObject(b.geometry,b.attributes,a[0]);c._underlyingGraphic=b;b=c}return b}):c.isArray(a[0])?0===a[0].length?u.resolve(null):u.resolve(a[0][0]):c.isImmutableArray(a[0])?0===a[0].length()?u.resolve(null):u.resolve(a[0].get(0)):null})},b.signatures.push({name:"first",min:"1",
max:"1"}),b.functions.attachments=function(k,d){return b.standardFunctionAsync(k,d,function(b,d,a){c.pcCheck(a,1,2);var e=-1,f=-1,m=null;if(1<a.length)if(a[1]instanceof H)a[1].hasField("minsize")&&(e=c.toNumber(a[1].field("minsize"))),a[1].hasField("maxsize")&&(f=c.toNumber(a[1].field("maxsize"))),a[1].hasField("types")&&(b=c.toStringArray(a[1].field("types"),!1),0<b.length&&(m=b));else if(null!==a[1])throw Error("Invalid Parameter");if(a[0]instanceof w){var r=a[0]._layer;r instanceof D&&(r=t.constructFeatureSet(r,
k.spatialReference,["*"],!0,k.lrucache));return null===r||!1===c.isFeatureSet(r)?[]:r.load().then(function(){return r.queryAttachments(a[0].field(r.objectIdField),e,f,m)})}if(null===a[0])return[];throw Error("Invalid Parameter");})},b.signatures.push({name:"attachments",min:"1",max:"2"}),b.functions.featuresetbyrelationshipname=function(k,d){return b.standardFunctionAsync(k,d,function(b,d,a){c.pcCheck(a,2,4);var e=a[0],f=c.toString(a[1]),m=c.defaultUndefined(a[2],null),r=c.toBoolean(c.defaultUndefined(a[3],
!0));null===m&&(m=["*"]);if(!1===c.isArray(m))throw Error("Invalid Parameter");if(null===a[0])return null;if(!(a[0]instanceof w))throw Error("Invalid Parameter");b=e._layer;b instanceof D&&(b=t.constructFeatureSet(b,k.spatialReference,["*"],!0,k.lrucache));return null===b||!1===c.isFeatureSet(b)?null:b.load().then(function(a){var b=a.relationshipMetaData().filter(function(b){return b.name===f});if(0===b.length)return null;if(void 0!==b[0].relationshipTableId&&null!==b[0].relationshipTableId&&-1<b[0].relationshipTableId)return t.constructFeatureSetFromRelationship(a,
b[0],e.field(a.objectIdField),a.spatialReference,m,r,k.lrucache);var c=a.serviceUrl();if(!c)return null;c="/"===c.charAt(c.length-1)?c+b[0].relatedTableId.toString():c+"/"+b[0].relatedTableId.toString();return t.constructFeatureSetFromUrl(c,a.spatialReference,m,r,k.lrucache).then(function(c){return c.load().then(function(){return c.relationshipMetaData()}).then(function(g){g=g.filter(function(a){return a.id===b[0].id});if(!1===e.hasField(b[0].keyField)||null===e.field(b[0].keyField))return a.getFeatureByObjectId(e.field(a.objectIdField),
[b[0].keyField]).then(function(a){if(a){var e=x.WhereClause.create(g[0].keyField+"\x3d @id",c.getFieldsIndex());e.parameters={id:a.attributes[b[0].keyField]};return c.filter(e)}return new Q({parentfeatureset:c})});var d=x.WhereClause.create(g[0].keyField+"\x3d @id",c.getFieldsIndex());d.parameters={id:e.field(b[0].keyField)};return c.filter(d)})})})})},b.signatures.push({name:"featuresetbyrelationshipname",min:"2",max:"4"}),b.functions.featuresetbyassociation=function(k,d){return b.standardFunctionAsync(k,
d,function(b,d,a){c.pcCheck(a,2,3);var e=a[0],f=c.toString(c.defaultUndefined(a[1],"")).toLowerCase(),m=c.isString(a[2])?c.toString(a[2]):null;if(null===a[0])return null;if(!(a[0]instanceof w))throw Error("Invalid Parameter");var r=e._layer;r instanceof D&&(r=t.constructFeatureSet(r,k.spatialReference,["*"],!0,k.lrucache));return null===r||!1===c.isFeatureSet(r)?null:r.load().then(function(){var a=r.serviceUrl();return t.constructAssociationMetaDataFeatureSetFromUrl(a,k.spatialReference)}).then(function(a){var b=
null,d=null,g=!1;if(null!==m&&""!==m&&void 0!==m){for(var k=0,h=a.terminals;k<h.length;k++){var l=h[k];l.terminalName===m&&(d=l.terminalId)}null===d&&(g=!0)}for(var y=a.associations.getFieldsIndex(),k=y.get("TOGLOBALID").name,h=y.get("FROMGLOBALID").name,u=y.get("TOTERMINALID").name,t=y.get("FROMTERMINALID").name,z=y.get("FROMNETWORKSOURCEID").name,w=y.get("TONETWORKSOURCEID").name,v=y.get("ASSOCIATIONTYPE").name,l=y.get("ISCONTENTVISIBLE").name,y=y.get("OBJECTID").name,n=0,B=r.fields;n<B.length;n++){var C=
B[n];if("global-id"===C.type){b=e.field(C.name);break}}var B=null,n={},A;for(A in a.lkp)n[A]=a.lkp[A].sourceId;A=new q.StringToCodeAdapted(new U({name:"classname",alias:"classname",type:"string"}),null,n);n="";switch(f){case "connected":v=k+"\x3d'@T'";n=h+"\x3d'@T'";null!==d&&(v+=" AND "+u+"\x3d@A",n+=" AND "+t+"\x3d@A");n=c.multiReplace("(("+v+") OR ("+n+"))","@T",b);v=c.multiReplace(v,"@T",b);null!==d&&(v=c.multiReplace(v,"@A",d.toString()),n=c.multiReplace(n,"@A",d.toString()));A.codefield=x.WhereClause.create("CASE WHEN "+
v+(" THEN "+z+" ELSE "+w+" END"),a.associations.getFieldsIndex());b=T.cloneField(q.AdaptedFeatureSet.findField(a.associations.fields,h));b.name="globalid";b.alias="globalid";B=new q.SqlExpressionAdapted(b,x.WhereClause.create("CASE WHEN "+v+(" THEN "+h+" ELSE "+k+" END"),a.associations.getFieldsIndex()));break;case "container":n=k+"\x3d'"+b+"' AND "+v+" \x3d 2",null!==d&&(n+=" AND "+u+" \x3d "+d.toString()),A.codefield=z,n="( "+n+" )",B=new q.FieldRename(q.AdaptedFeatureSet.findField(a.associations.fields,
h),"globalid","globalid");case "content":n="("+h+"\x3d'"+b+"' AND "+v+" \x3d 2)";null!==d&&(n+=" AND "+t+" \x3d "+d.toString());A.codefield=w;n="( "+n+" )";B=new q.FieldRename(q.AdaptedFeatureSet.findField(a.associations.fields,k),"globalid","globalid");break;case "structure":n="("+k+"\x3d'"+b+"' AND "+v+" \x3d 3)";null!==d&&(n+=" AND "+u+" \x3d "+d.toString());A.codefield=z;n="( "+n+" )";B=new q.FieldRename(q.AdaptedFeatureSet.findField(a.associations.fields,h),"globalid","globalId");break;case "attached":n=
"("+h+"\x3d'"+b+"' AND "+v+" \x3d 3)";null!==d&&(n+=" AND "+t+" \x3d "+d.toString());A.codefield=w;n="( "+n+" )";B=new q.FieldRename(q.AdaptedFeatureSet.findField(a.associations.fields,k),"globalid","globalId");break;default:throw Error("Invalid Parameter");}g&&(n="1 \x3c\x3e 1");return new q.AdaptedFeatureSet({parentfeatureset:a.associations,adaptedFields:[new q.OriginalField(q.AdaptedFeatureSet.findField(a.associations.fields,y)),new q.OriginalField(q.AdaptedFeatureSet.findField(a.associations.fields,
l)),B,A],extraFilter:n?x.WhereClause.create(n,a.associations.getFieldsIndex()):null})})})},b.signatures.push({name:"featuresetbyassociation",min:"2",max:"6"}),b.functions.groupby=function(k,d){return b.standardFunctionAsync(k,d,function(d,f,a){c.pcCheck(a,3,3);return c.isFeatureSet(a[0])?a[0].load().then(function(e){var d=[],f=[],h=!1,g=[];if(c.isString(a[1]))g.push(a[1]);else if(a[1]instanceof z)g.push(a[1]);else if(c.isArray(a[1]))g=a[1];else if(c.isImmutableArray(a[1]))g=a[1].toArray();else return b.failDefferred("Illegal Value: GroupBy");
for(var l=0,q=g;l<q.length;l++){var p=q[l];if(c.isString(p))g=x.WhereClause.create(c.toString(p),e.getFieldsIndex()),p=!0===K.isSingleField(g)?c.toString(p):"%%%%FIELDNAME",d.push({name:p,expression:g}),"%%%%FIELDNAME"===p&&(h=!0);else if(p instanceof z){var t=p.hasField("name")?p.field("name"):"%%%%FIELDNAME",g=p.hasField("expression")?p.field("expression"):"";"%%%%FIELDNAME"===t&&(h=!0);if(!t)return b.failDefferred("Illegal Value: GroupBy");d.push({name:t,expression:x.WhereClause.create(g?g:t,e.getFieldsIndex())})}else return b.failDefferred("Illegal Value: GroupBy")}g=
[];if(c.isString(a[2]))g.push(a[2]);else if(c.isArray(a[2]))g=a[2];else if(c.isImmutableArray(a[2]))g=a[2].toArray();else if(a[2]instanceof z)g.push(a[2]);else return b.failDefferred("Illegal Value: GroupBy");l=0;for(q=g;l<q.length;l++)if(p=q[l],p instanceof z){var t=p.hasField("name")?p.field("name"):"",w=p.hasField("statistic")?p.field("statistic"):"",g=p.hasField("expression")?p.field("expression"):"";if(!t||!w||!g)return b.failDefferred("Illegal Value: GroupBy");f.push({name:t,statistic:w.toLowerCase(),
expression:x.WhereClause.create(g,e.getFieldsIndex())})}else return b.failDefferred("Illegal Value: GroupBy");if(h){h={};g=0;for(p=e.fields;g<p.length;g++)e=p[g],h[e.name.toLowerCase()]=1;for(g=0;g<d.length;g++)e=d[g],"%%%%FIELDNAME"!==e.name&&(h[e.name.toLowerCase()]=1);for(g=0;g<f.length;g++)e=f[g],"%%%%FIELDNAME"!==e.name&&(h[e.name.toLowerCase()]=1);for(p=g=0;p<d.length;p++)if(e=d[p],"%%%%FIELDNAME"===e.name){for(;1===h["field_"+g.toString()];)g++;h["field_"+g.toString()]=1;e.name="FIELD_"+g.toString()}}e=
[];for(g=0;g<d.length;g++)h=d[g],e.push(E(h.expression,b,k));for(g=0;g<f.length;g++)h=f[g],e.push(E(h.expression,b,k));return 0<e.length?u.all(e).then(function(){return u.resolve(a[0].groupby(d,f))}):u.resolve(a[0].groupby(d,f))}):b.failDefferred("Illegal Value: GroupBy")})},b.signatures.push({name:"groupby",min:"3",max:"3"}),b.functions.distinct=function(h,d){return b.standardFunctionAsync(h,d,function(d,f,a){return c.isFeatureSet(a[0])?(c.pcCheck(a,2,2),a[0].load().then(function(d){var e=[],f=[];
if(c.isString(a[1]))f.push(a[1]);else if(a[1]instanceof z)f.push(a[1]);else if(c.isArray(a[1]))f=a[1];else if(c.isImmutableArray(a[1]))f=a[1].toArray();else return b.failDefferred("Illegal Value: GroupBy");for(var k=!1,g=0;g<f.length;g++){var l=f[g];if(c.isString(l)){var q=x.WhereClause.create(c.toString(l),d.getFieldsIndex()),l=!0===K.isSingleField(q)?c.toString(l):"%%%%FIELDNAME";e.push({name:l,expression:q});"%%%%FIELDNAME"===l&&(k=!0)}else if(l instanceof z){var p=l.hasField("name")?l.field("name"):
"%%%%FIELDNAME",q=l.hasField("expression")?l.field("expression"):"";"%%%%FIELDNAME"===p&&(k=!0);if(!p)return b.failDefferred("Illegal Value: GroupBy");e.push({name:p,expression:x.WhereClause.create(q?q:p,d.getFieldsIndex())})}else return b.failDefferred("Illegal Value: GroupBy")}if(k){k={};g=0;for(f=d.fields;g<f.length;g++)d=f[g],k[d.name.toLowerCase()]=1;for(g=0;g<e.length;g++)d=e[g],"%%%%FIELDNAME"!==d.name&&(k[d.name.toLowerCase()]=1);for(f=g=0;f<e.length;f++)if(d=e[f],"%%%%FIELDNAME"===d.name){for(;1===
k["field_"+g.toString()];)g++;k["field_"+g.toString()]=1;d.name="FIELD_"+g.toString()}}d=[];for(k=0;k<e.length;k++)d.push(E(e[k].expression,b,h));return 0<d.length?u.all(d).then(function(){return u.resolve(a[0].groupby(e,[]))}):u.resolve(a[0].groupby(e,[]))})):V("distinct",d,f,a)})})}});