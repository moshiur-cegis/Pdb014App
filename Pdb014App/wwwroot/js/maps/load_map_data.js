

var map,
    mapZoom = 7,
    dataCode,
    dataName,
    dataAdminCode,
    dataAdminName,
    //data_type = 1,
    map_data = [],
    dataLayer = null,
    mapLabels = new L.LayerGroup(),
    mapLayers = {},
    polyDefaultOptions = {
        zIndex: 101,
        weight: 1.0,
        opacity: 0.9,
        color: "#D0C0A0",
        fillOpacity: 0.8
    },
    adminFocused = null;


$(function () {

    //dataAdminCode = $("#admin_info").val();
    //dataAdminName = $("#admin_info option:selected").text();

    //$("#map_label_opt").prop("checked", false);

    set_basic_opts();

    add_admin_boundary("div", true);

    //add_admin_boundary("dist", false);

    //add_admin_boundary("upaz", false);

    //add_admin_boundary("union", false);

    //map_label_show_hide(true);

    //add_remove_admin_label("div", true);
    //add_remove_admin_label("dist", true);

    //set_map_filter("div", "30");


    //draggable_modal("option_title", "map_filter_content", "map_filter_bg", false);

    //draggable_modal("data_title", "map_data_content", "map_data_bg", false);

});

function set_basic_opts() {

    if (typeof L == "undefined" || L == undefined) {
        legend_open_close("legend", "close", "right");
        $("#legend").css("right", "-1000px");
        legend_open_close("legend_info", "close", "left");
        $("#legend_info").css("left", "-1000px");

        msg.init("error", "Error... . .", "Map Loading Failed !");
        $("#busy-indicator").fadeOut();

        return false;
    }


    var blankUrl = "../images/blank.png",
        osmUrl = "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        googleUrlHy = "http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}",
        googleUrlSa = "http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}",
        googleUrlSt = "http://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}",
        googleUrlTr = "http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}",
        mapBoxUrl = "https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiYWxoYWRpLWNzZSIsImEiOiJjamx1azJ5emcwamlkM3ZxeHB0ajB0d3I1In0.k_DovXLLPpp7fQ_i685ocA",
        esriUrl = "http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}",
        mapAttr = "Map data © <a href='https://www.cegisbd.com/' target='_blank'>CEGIS</a> & <a href='http://www.bpdb.gov.bd/bpdb_new/' target='_blank'>BPDB</a>";

    var openstreet = L.tileLayer(osmUrl, { id: 'MapID', minZoom: 0, maxZoom: 25, attribution: mapAttr }),
        googleHy = L.tileLayer(googleUrlHy, { id: 'MapID', minZoom: 0, maxZoom: 25, subdomains: ["mt0", "mt1", "mt2", "mt3"], attribution: mapAttr }),
        googleSa = L.tileLayer(googleUrlSa, { id: 'MapID', minZoom: 0, maxZoom: 25, subdomains: ["mt0", "mt1", "mt2", "mt3"], attribution: mapAttr }),
        googleSt = L.tileLayer(googleUrlSt, { id: 'MapID', minZoom: 0, maxZoom: 25, subdomains: ["mt0", "mt1", "mt2", "mt3"], attribution: mapAttr }),
        googleTr = L.tileLayer(googleUrlTr, { id: 'MapID', minZoom: 0, maxZoom: 25, subdomains: ["mt0", "mt1", "mt2", "mt3"], attribution: mapAttr }),
        mapboxLi = L.tileLayer(mapBoxUrl, { id: 'MapID', minZoom: 0, maxZoom: 25, id: "mapbox.light", attribution: mapAttr }),
        mapboxSt = L.tileLayer(mapBoxUrl, { id: 'MapID', minZoom: 0, maxZoom: 25, id: "mapbox.streets", attribution: mapAttr }),
        esri = L.tileLayer(esriUrl, { id: 'MapID', minZoom: 0, maxZoom: 25, attribution: mapAttr }),
        blank = L.tileLayer(blankUrl, { id: 'MapID', minZoom: 0, maxZoom: 25, attribution: mapAttr });

    //L.mapbox.accessToken = "pk.eyJ1IjoiYWxoYWRpLWNzZSIsImEiOiJjamx1azJ5emcwamlkM3ZxeHB0ajB0d3I1In0.k_DovXLLPpp7fQ_i685ocA";
    //{id: 'MapID', attribution: mapboxAttribution}

    map = new L.Map("map",
        {
            center: new L.LatLng(23.737777, 90.537777),
            fullscreenControl: true,
            zoomControl: false,
            maxZoom: 20,
            minZoom: 2,
            zoom: 7.0,
            layers: [openstreet]
        });

    map.setView([23.737777, 90.537777], 7.0);


    var baseMaps = {
        "Open Street": openstreet,
        "Google Hybrid": googleHy,
        "Google Satellite": googleSa,
        "Google Streets": googleSt,
        "Google Terrain": googleTr,
        "Mapbox Light": mapboxLi,
        "Mapbox Streets": mapboxSt,
        "ESRI": esri,
        "None": blank
    };


    //map.createPane("data-layer").style.zIndex = 401;
    //map.createPane("other-layer").style.zIndex = 403;
    map.createPane("admin-layer").style.zIndex = 405;

    //map.createPane("marker-layer").style.zIndex = 600;
    map.createPane("label-layer").style.zIndex = 601;

    //map.createPane("admin").style.zIndex = 455;

    //drawnItems.addTo(map);
    //drawnItems.addTo(map);

    L.tileLayer("", { attribution: mapAttr }).addTo(map);
    //L.control.layers(baseMaps, { "Select Layer": drawnItems }, { position: "topright", collapsed: true }).addTo(map);

    L.control.scale().addTo(map);
    //L.control.pan().addTo(map);
    L.control.zoom().addTo(map);

    map.on("mousemove",
        function (evt) {
            $("#map_cord_info").html(evt.latlng.lat.toFixed(8) + ", " + evt.latlng.lng.toFixed(8));
        });

    $("#map_center").on("click",
        function (e) {
            map.setView([23.737777, 90.537777], 7.0);
        });

    //L.control.layers(null, baseMaps, { collapsed: false }).addTo(map);
    var bgLayers = L.control.layers(baseMaps, null, { collapsed: false });

    bgLayers.addTo(map);
    //$("#bg_layers_content").append(bgLayers.getContainer());

    var bgLayersContent = $(bgLayers.getContainer());
    bgLayersContent.find("a.leaflet-control-layers-toggle").remove();
    bgLayersContent.find("form.leaflet-control-layers-list").css("display", "block");
    $("#map_bg_layers").append(bgLayersContent);


    //add_admin_boundary("div");


    //$("#map_label_opt").on("change",
    //    function () {
    //        map_label_show_hide(this.checked);
    //    });

    //$("#map_full_screen").on("click",
    //    function () {
    //        if (!confirm("Are you sure to close full screen ?"))
    //            return;

    //        $("#map_info").toggleClass("map-full-screen");
    //    });

    //$("input[type='checkbox'].multi-chkbx.admin").each(function () {
    //    $(this).on("change",
    //        function () {

    //            if (!$(this).prop("id").replace("admin_", ""))
    //                return;

    //            var adminCode = $(this).prop("id").replace("admin_", "");

    //            $("#busy-indicator").fadeIn();

    //            if (this.checked)
    //                add_admin_boundary(adminCode);
    //            else
    //                remove_admin_boundary(adminCode);

    //            $("#busy-indicator").fadeOut();
    //        });
    //});

    //$("input[type='checkbox'].multi-chkbx.admin-label").each(function () {
    //    $(this).on("change",
    //        function () {
    //            if (!$(this).prop("id").replace("admin_label_", ""))
    //                return;

    //            var adminCode = $(this).prop("id").replace("admin_label_", "");

    //            $("#busy-indicator").fadeIn();

    //            add_remove_admin_label(adminCode, this.checked);

    //            $("#busy-indicator").fadeOut();
    //        });
    //});



    //$("#legend_info_opt").change(function () {
    //    if (this.checked) {
    //        legend_open_close("legend_info", "open", "left");
    //    } else {
    //        legend_open_close("legend_info", "close", "left");
    //    }
    //    return false;
    //});

    //$("#legend_opt").change(function () {
    //    if (this.checked) {
    //        legend_open_close("legend", "open", "right");
    //    } else {
    //        legend_open_close("legend", "close", "right");
    //    }
    //    return false;
    //});

    return true;
}


var isOpened = false, isDataOpened = false;

function map_filter_open_close(content, isOpen) {
    if (isOpened === isOpen) return;

    if (isOpen && !isOpened)
        modal_open(content, 50);
    else if (!isOpen && isOpened)
        modal_close(content);

    isOpened = isOpen;
}

function map_data_open_close(content, isOpen) {
    if (isDataOpened === isOpen) return;

    if (isOpen && !isDataOpened)
        modal_open(content, 25);
    else if (!isOpen && isDataOpened)
        modal_close(content);

    isDataOpened = isOpen;
}

function legend_open_close(legendId, openCloseOpt, propOpt) {
    if (openCloseOpt == "open") {
        $("#" + legendId + "_btn")
            .css(propOpt, "-" + ($("#" + legendId + "_btn").outerWidth(true) + 10) + "px");
        $("#" + legendId).css(propOpt, "-2px");

        $("#" + legendId + "_opt").prop("checked", true);
    } else if (openCloseOpt == "close") {
        $("#" + legendId).css(propOpt, "-" + ($("#" + legendId).outerWidth(true) + 5) + "px");
        $("#" + legendId + "_btn").css(propOpt, "-10px");

        $("#" + legendId + "_opt").prop("checked", false);
    }
}




function add_remove_admin_label(adminCode, isShow) {

    if (!adminCode || !mapLayers["admin_" + adminCode] || !mapLayers["admin_" + adminCode].label)
        return;

    if (isShow && !map.hasLayer(mapLayers["admin_" + adminCode].label)) {
        map.addLayer(mapLayers["admin_" + adminCode].label);
        return;
    }

    if (!isShow && map.hasLayer(mapLayers["admin_" + adminCode].label)) {
        map.removeLayer(mapLayers["admin_" + adminCode].label);
        return;
    }

    return;
}

function remove_admin_boundary(adminCode) {
    if (!adminCode) return;

    if (mapLayers["admin_" + adminCode]) {
        if (map.hasLayer(mapLayers["admin_" + adminCode].layer))
            map.removeLayer(mapLayers["admin_" + adminCode].layer);

        if (map.hasLayer(mapLayers["admin_" + adminCode].label))
            map.removeLayer(mapLayers["admin_" + adminCode].label);
    }
    return;
}

function add_admin_boundary(adminCode, showLabel, selectedAdminCode) {
    if (!adminCode) return;

    var labelClass = "map_label",
        labelContent = "",
        offsetLeft = 0,
        lineStyle = {
            pane: "admin-layer",
            color: "#5A3322",
            weight: 1.0,
            opacity: 1,
            scale: 0.5,
            fill: false,
            fillColor: null,
            fillOpacity: 0.0
        },
        hoverStyle = {
            dashArray: null,
            zIndex: 9999,
            weight: 2.5,
            fill: false,
            color: "#FC4F3A",
            opacity: 1.0,
            fillColor: null,
            fillOpacity: 0.15
        },
        focusStyle = {
            dashArray: null,
            zIndex: 9999,
            weight: 3.0,
            fill: true,
            color: "#3587EA",
            opacity: 1.0,
            fillColor: "#35A3E8",
            fillOpacity: 0.15
        };

    switch (adminCode) {
        case "div":
            lineStyle.zIndex = 107;
            lineStyle.dashArray = "7 3 2 4 2 3";
            lineStyle.color = "#3A2211";
            lineStyle.weight = 1.5;
            lineStyle.scale = 1.5;

            hoverStyle.weight = 2.5;

            offsetLeft = 10;
            labelClass = "map_admin_label";

            labelContent = "<span style='font-size:15px;font-weight:500;color:#123;'>▣ ";
            break;

        case "dist":
            lineStyle.zIndex = 105;
            lineStyle.dashArray = "5 2 1 3 1 2";
            lineStyle.color = "#5A3322";
            lineStyle.weight = 1.0;
            lineStyle.scale = 1.0;

            hoverStyle.weight = 1.5;

            offsetLeft = 10;
            labelClass = "map_admin_label";

            labelContent = "<span style='font-size:13px;font-weight:400;color:#137;'>☐ ";
            break;

        case "upaz":
            lineStyle.zIndex = 103;
            lineStyle.dashArray = "3 2";
            lineStyle.color = "#4A0000";
            lineStyle.weight = 0.5;
            lineStyle.scale = 0.7;

            hoverStyle.weight = 1.0;

            labelContent = "⚀ ";
            break;

        case "union":
            lineStyle.zIndex = 102;
            lineStyle.dashArray = "2 4";
            lineStyle.color = "#AA5533";
            lineStyle.weight = 0.5;
            lineStyle.scale = 0.5;

            hoverStyle.weight = 1.0;
            labelContent = "☉ ";
            break;

        default:
            hoverStyle.weight = 1.0;

            labelContent = "";
            break;
    }

    if (mapLayers["admin_" + adminCode]) {

        if (map.hasLayer(mapLayers["admin_" + adminCode].layer))
            map.removeLayer(mapLayers["admin_" + adminCode].layer);

        if (map.hasLayer(mapLayers["admin_" + adminCode].label))
            map.removeLayer(mapLayers["admin_" + adminCode].label);
    }


    var adminLayer = null,
        adminLabels = new L.LayerGroup(),
        adminLayerPath = "../js/maps/map_data/" + adminCode + ".json";

    adminLayer = L.geoJson(null, {
        style: lineStyle,
        onEachFeature: function (feature, layer) {
            getMapLabels(feature, layer, adminCode, labelClass, adminLabels, labelContent, offsetLeft, lineStyle, hoverStyle, focusStyle);
            //getMapLabels(feature, layer, adminCode, adminLabels, lineStyle);

            //if (adminCode == "union") {
            //    layer.on({
            //        "click": function (e) {
            //            var unionCode = feature.properties[adminCode + "_code"];
            //            if (e.latlng)
            //                set_location_data(unionCode, "", e.latlng.lat.toFixed(8), e.latlng.lng.toFixed(8));

            //        }
            //    });
            //}


            switch (adminCode) {
                case "div":
                    focusStyle.weight = 3.25;
                    focusStyle.color = "#3587EA";
                    focusStyle.fillColor = "#35A3E8";
                    break;

                case "dist":
                    focusStyle.weight = 3.0;
                    focusStyle.color = "#6513F3";
                    focusStyle.fillColor = "#8528FC";
                    break;

                case "upaz":
                    focusStyle.weight = 2.75;
                    focusStyle.color = "#17A3B8";
                    focusStyle.fillColor = "#27C5D7";//#20c997;#17a2b8;

                    break;

                case "union":
                    focusStyle.weight = 2.5;
                    focusStyle.color = "#DC3545";
                    focusStyle.fillColor = "#FA4575";
                    
                    layer.on({
                        "click": function (e) {
                            var unionCode = feature.properties[adminCode + "_code"];
                            if (e.latlng) {
                                set_location_data(unionCode, "", e.latlng.lat.toFixed(8), e.latlng.lng.toFixed(8));
                            }
                        }
                    });
                    break;

                default:
                    focusStyle.weight = 3.5;
                    focusStyle.color = "#3587EA";
                    focusStyle.fillColor = "#35A3E8";
                    break;
            }


            if (selectedAdminCode && feature.properties[adminCode + "_code"] == selectedAdminCode) {

                layer.className = "focused";
                layer.setStyle(focusStyle);

                map.fitBounds(layer.getBounds());
                return;

                //var polyCenter = new L.LatLng(feature.properties["CNT_LAT"], feature.properties["CNT_LONG"]),
                //    zoomLevel = adminCode == "div" ? 8.0 : adminCode == "dist" ? 9.5 : adminCode =="upaz" ? 11.0 : 12.0;

                ////zoomLevel = map.getZoom() > zoomLevel ? map.getZoom() : zoomLevel;

                //map.setView(polyCenter, zoomLevel);
            }
        },
        //onEachFeature: getMapLabels,
        filter: function (feature, layer) {
            return selectedAdminCode ? setMapFilter(feature, adminCode + "_code", selectedAdminCode) : true;
        }
    });

    $.getJSON(adminLayerPath, function (adminLayerInfo) {
        if (!adminLayerInfo) return;

        adminLayer.addData(adminLayerInfo);
    }).done(function (e) {
        mapLayers["admin_" + adminCode] = { layer: adminLayer, label: adminLabels };

        map.addLayer(mapLayers["admin_" + adminCode].layer);

        if (!selectedAdminCode && (adminCode == "upaz" || adminCode == "union")) {
            var labelGroups = new L.MarkerClusterGroup({
                disableClusteringAtZoom: adminCode == "upaz" ? 10 : 11,
                pane: "label-layer"
            });
            labelGroups.addLayer(adminLabels);
            mapLayers["admin_" + adminCode]["label"] = labelGroups;
        }

        if (showLabel)
            map.addLayer(mapLayers["admin_" + adminCode].label);

    });

    return;
}

function getMapLabels(feature, layer, adminCode, labelClass, adminLabels, labelContent, offsetLeftDefault, defaultStyle, hoverStyle, focusStyle) {

    var adminFieldName = adminCode + "_name";

    var currAdminName = feature.properties[adminFieldName],
        polyCenter = new L.LatLng(feature.properties["CNT_LAT"], feature.properties["CNT_LONG"]),
        offsetTop = 10,
        offsetLeft = ((285 * currAdminName.length) / 100) + offsetLeftDefault;

    defaultStyle = defaultStyle
        ? defaultStyle
        : { opacity: 1, scale: 0.5, color: "#5A3322", weight: 1.0, fill: false, fillColor: null, fillOpacity: 0.0 };
    labelContent = labelContent ? labelContent + currAdminName + "</span>" : currAdminName;

    //,
    //labelClass = "map_label",
    //labelContent,
    //hoverStyle = { dashArray: null, zIndex: 9999, weight: 2.5, fill: false, color: "#FC4F3A", opacity: 1.0, fillColor: null, fillOpacity: 0.15 },
    //focusStyle = { dashArray: null, zIndex: 9999, weight: 3.0, fill: true, color: "#3587EA", opacity: 1.0, fillColor: "#35A3E8", fillOpacity: 0.15 };

    //switch (adminCode) {
    //    case "div":
    //        defaultStyle.weight = 1.5;
    //        hoverStyle.weight = 2.5;

    //        offsetLeft += 10;
    //        labelClass = "map_admin_label";

    //        labelContent = "<span style='font-size:15px;font-weight:500;color:#123;'>▣ " + currAdminName + "</span>";
    //        break;

    //    case "dist":
    //        defaultStyle.weight = 1.0;
    //        hoverStyle.weight = 1.5;

    //        offsetLeft += 10;
    //        labelClass = "map_admin_label";

    //        labelContent = "<span style='font-size:13px;font-weight:400;color:#137;'>☐ " + currAdminName + "</span>";
    //        break;

    //    case "upaz":
    //        defaultStyle.weight = 0.5;
    //        hoverStyle.weight = 1.0;

    //        labelContent = "⚀ " + currAdminName;
    //        break;

    //    case "union":
    //        defaultStyle.weight = 0.25;
    //        hoverStyle.weight = 1.0;
    //        labelContent = "☉ " + currAdminName;
    //        break;

    //    default:
    //        defaultStyle.weight = 0.5;
    //        hoverStyle.weight = 1.0;

    //        labelContent = currAdminName;
    //        break;
    //}

    var labelInfo = new L.Marker(polyCenter, {
        pane: "label-layer",
        icon: L.divIcon({
            iconSize: null,
            className: labelClass,
            iconAnchor: [offsetLeft, offsetTop],
            html: labelContent
        })
    }).on({
        "mouseover": function (e) {
            var isFocus = layer.className && layer.className == "focused";
            layer.setStyle(isFocus ? focusStyle : hoverStyle);
        },
        "mouseout": function (e) {
            var isFocus = layer.className && layer.className == "focused";
            layer.setStyle(isFocus ? focusStyle : defaultStyle);
        }
    });

    //layer.on({
    //    "click": function (e) {

    //        SetAdminData(adminCode, feature.properties);

    //        //if (adminCode == "union") {
    //        //    var unionCode = feature.properties["union_code"],
    //        //        unionName = feature.properties["union_name"],
    //        //        upazName = feature.properties["upaz_name"],
    //        //        distName = feature.properties["dist_name"],
    //        //        divName = feature.properties["div_name"];

    //        //    SetUnionData(unionCode, unionName, upazName, distName, divName);
    //        //}

    //        if (layer.className && layer.className == "focused") {
    //            layer.className = "";
    //            layer.setStyle(hoverStyle);
    //        }

    //        if (adminFocused && adminFocused.layer && adminFocused.layer == layer) {
    //            adminFocused.layer.className = "";
    //            adminFocused.layer.setStyle(defaultStyle);

    //            adminFocused = null;
    //        }
    //    }
    //});
    //.on({
    //    "mouseover": function (e) {
    //        var isFocus = layer.className && layer.className == "focused";
    //        layer.setStyle(isFocus ? focusStyle : hoverStyle);
    //    },
    //    "mouseout": function (e) {
    //        var isFocus = layer.className && layer.className == "focused";
    //        layer.setStyle(isFocus ? focusStyle : defaultStyle);
    //    }
    //});


    //if (adminCode == "div" || adminCode == "dist") {

    //    labelInfo.on("click", function (e) {

    //        if (adminFocused && adminFocused.layer && adminFocused.layer != layer) {
    //            adminFocused.layer.className = "";
    //            adminFocused.layer.setStyle(defaultStyle);
    //        }
    //        adminFocused = null;

    //        if (layer.className && layer.className == "focused") {
    //            layer.className = "";
    //            layer.setStyle(hoverStyle);

    //            //layer.setZIndex(400);
    //            //layer.setZIndexOffset(0);
    //            return;
    //        }

    //        layer.className = "focused";
    //        layer.setStyle(focusStyle);
    //        //layer.setZIndex(450);
    //        //layer.setZIndexOffset(250);

    //        adminFocused = { layer: layer, label: labelInfo };

    //        var geoCode = feature.properties[adminCode + "_code"],
    //            zoomLevel = (geoCode && (geoCode == 20 || geoCode == 30 || geoCode == 40)) ? 7.5 : 8.5;

    //        //zoomLevel = map.getZoom() > zoomLevel ? map.getZoom() : zoomLevel;
    //        //zoomLevel = adminCode == "dist" ? zoomLevel + 1.5 : zoomLevel;
    //        zoomLevel = map.getZoom() > zoomLevel
    //            ? map.getZoom()
    //            : adminCode == "dist"
    //                ? zoomLevel + 1.5 : zoomLevel;

    //        map.setView(polyCenter, zoomLevel);
    //    });
    //}


    labelInfo.on("click", function (e) {

        if (adminFocused && adminFocused.layer && adminFocused.layer != layer) {
            adminFocused.layer.className = "";
            adminFocused.layer.setStyle(defaultStyle);
        }
        adminFocused = null;

        if (layer.className && layer.className == "focused") {
            layer.className = "";
            layer.setStyle(hoverStyle);
            return;
        }

        layer.className = "focused";
        layer.setStyle(focusStyle);

        adminFocused = { layer: layer, label: labelInfo };
    });


    adminLabels.addLayer(labelInfo);

    return;
}


function setMapFilter(feature, adminCodeField, selectedAdminCode) {
    if (!feature || !feature.properties[adminCodeField] || feature.properties[adminCodeField] != selectedAdminCode)
        return false;
    else
        return true;
}

