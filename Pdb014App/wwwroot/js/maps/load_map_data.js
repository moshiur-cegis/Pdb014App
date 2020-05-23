

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



    /*




    L.marker([23.737777, 90.537777], {
        icon: L.BeautifyIcon.icon(),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");







    var options = {
        icon: 'bus',
        borderColor: '#b3334f',
        textColor: '#b3334f'
    };
    L.marker([23.89093747081252, 89.9107666015625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'plane',
        borderColor: '#8D208B',
        textColor: '#8D208B',
        backgroundColor: 'transparent'
    };
    L.marker([23.89093747081252, 90.0426025390625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'ambulance',
        borderColor: 'Red',
        textColor: 'Red',
        innerIconStyle: 'font-size:11px;padding-top:1px;'
    };
    L.marker([23.89093747081252, 90.17718505859375], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'taxi',
        borderColor: 'red',
        textColor: 'Red',
        backgroundColor: '#FFF607',
        innerIconStyle: 'font-size:9px;padding-top:1px;'
    };
    L.marker([23.89093747081252, 90.32000732421875], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        isAlphaNumericIcon: true,
        borderColor: '#00ABDC',
        textColor: '#00ABDC',
        innerIconStyle: 'margin-top:0;'
    };
    L.marker([23.89093747081252, 90.49029541015625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'spinner',
        spin: 'true',
        borderColor: '#8A90B4',
        textColor: 'white',
        backgroundColor: '#8A90B4'
    };
    L.marker([23.89093747081252, 90.65509033203125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");






    options = {
        icon: 'leaf',
        iconShape: 'marker'
    };
    L.marker([23.73, 89.77069091796875], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("popup").bindPopup("I'm Beautify");

    options = {
        icon: 'bus',
        iconShape: 'marker',
        borderColor: '#b3334f',
        textColor: '#b3334f'
    };
    L.marker([23.73, 89.90802001953125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'plane',
        iconShape: 'marker',
        borderColor: '#8D208B',
        textColor: '#8D208B',
        backgroundColor: 'transparent'
    };
    L.marker([23.73, 90.037109375], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'ambulance',
        iconShape: 'marker',
        borderColor: 'Red',
        textColor: 'Red',
        innerIconStyle: 'font-size:11px;padding-top:1px;'
    };
    L.marker([23.73, 90.17718505859375], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'close',
        iconShape: 'marker',
        borderColor: '#FFF607',
        textColor: 'Red',
        backgroundColor: 'red',
        innerIconStyle: 'font-size:9px;padding-top:1px;'
    };
    L.marker([23.73, 90.3172607421875], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        isAlphaNumericIcon: true,
        text: 10,
        iconShape: 'marker',
        borderColor: '#00ABDC',
        textColor: '#00ABDC'
    };
    L.marker([23.73, 90.487548828125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        icon: 'refresh',
        iconShape: 'marker',
        spin: 'true',
        borderColor: '#8A90B4',
        textColor: '#8A90B4'
    };
    L.marker([23.73, 90.65509033203125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5
    };

    L.marker([23.66, 89.76519775390625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("popup").bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: '#b3334f'
    };

    L.marker([23.66, 89.9052734375], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: '#8D208B'
    };

    L.marker([23.66, 90.037109375], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: 'red'
    };

    L.marker([23.66, 90.17993164062499], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: '#FFF607'
    };

    L.marker([23.66, 90.32550048828125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: '#00ABDC'
    };

    L.marker([23.66, 90.4930419921875], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'doughnut',
        borderWidth: 5,
        borderColor: '#8A90B4'
    };

    L.marker([23.66, 90.66333007812499], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");








    options = {
        iconShape: 'circle-dot',
        borderWidth: 5
    };

    L.marker([23.55, 89.76519775390625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: '#b3334f'
    };

    L.marker([23.55, 89.90802001953125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: '#8D208B'
    };

    L.marker([23.55, 90.03436279296875], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: 'red'
    };

    L.marker([23.55, 90.17993164062499], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: '#FFF607'
    };

    L.marker([23.55, 90.32550048828125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: '#00ABDC'
    };

    L.marker([23.55, 90.49029541015625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'circle-dot',
        borderWidth: 5,
        borderColor: '#8A90B4'
    };

    L.marker([23.55, 90.66333007812499], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");





    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5
    };

    L.marker([23.45, 89.76519775390625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: '#b3334f'
    };

    L.marker([23.45, 89.90802001953125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: '#8D208B'
    };

    L.marker([23.45, 90.03985595703124], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: 'red'
    };

    L.marker([23.45, 90.18267822265625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: '#FFF607'
    };

    L.marker([23.45, 90.32550048828125], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: '#00ABDC'
    };

    L.marker([23.45, 90.49029541015625], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");

    options = {
        iconShape: 'rectangle-dot',
        borderWidth: 5,
        borderColor: '#8A90B4'
    };

    L.marker([23.45, 90.66333007812499], {
        icon: L.BeautifyIcon.icon(options),
        draggable: true
    }).addTo(map).bindPopup("I'm Beautify");


*/







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

var newMarker;
function add_marker(latlng, fillColor, unionCode, sndCode) {

    if (map.hasLayer(newMarker))
        map.removeLayer(newMarker);

    var markerOpts = {
        icon: "close",
        iconShape: "marker",
        borderColor: "#FFF607",
        textColor: "White",
        backgroundColor: fillColor,
        innerIconStyle: "font-size:9px; padding-top:1px;"
    };

    newMarker = L.marker(latlng,
        {
            icon: L.BeautifyIcon.icon(markerOpts),
            draggable: true
        })
        .on('dragend',
            function (e) {
                set_location_data(unionCode, sndCode, e.target.getLatLng());
            })
        .bindPopup("<b>New Complain !!!</b><br />A complaint will be added to this position.").openPopup();

    map.addLayer(newMarker);

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

function add_admin_boundary(adminCode, showLabel, filterValue, filterField) {
    if (!adminCode) return;

    filterField = filterField || adminCode + "_code";

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

            switch (adminCode) {
                case "div":
                    focusStyle.weight = 3.25;
                    focusStyle.color = "#3587EA";
                    focusStyle.fillColor = "#35A3E8";

                    layer.on({
                        "click": function onDivClick(e) {
                            if (feature.properties[adminCode + "_code"]) {
                                var divCode = feature.properties[adminCode + "_code"];
                                add_admin_boundary("dist", true, divCode, "div_code");

                                layer.className = "focused";
                                layer.setStyle(focusStyle);

                                map.fitBounds(layer.getBounds());
                                //return;
                            }
                        }
                    });

                    break;

                case "dist":
                    focusStyle.weight = 3.0;
                    focusStyle.color = "#6513F3";
                    focusStyle.fillColor = "#8528FC";

                    layer.on({
                        "click": function onDistClick(e) {
                            if (feature.properties[adminCode + "_code"]) {
                                var distCode = feature.properties[adminCode + "_code"];
                                add_admin_boundary("upaz", true, distCode, "dist_code");

                                layer.className = "focused";
                                layer.setStyle(focusStyle);

                                map.fitBounds(layer.getBounds());
                                //return;
                            }
                        }
                    });

                    break;

                case "upaz":
                    focusStyle.weight = 2.75;
                    focusStyle.color = "#17A3B8";
                    focusStyle.fillColor = "#27C5D7";//#20c997;#17a2b8;

                    layer.on({
                        "click": function onUpazClick(e) {
                            if (feature.properties[adminCode + "_code"]) {
                                var upazCode = feature.properties[adminCode + "_code"];
                                add_admin_boundary("union", true, upazCode, "upaz_code");

                                layer.className = "focused";
                                layer.setStyle(focusStyle);

                                map.fitBounds(layer.getBounds());
                                //return;
                            }
                        }
                    });

                    break;

                case "union":
                    focusStyle.weight = 2.5;
                    focusStyle.color = "#DC3545";
                    focusStyle.fillColor = "#FA4575";

                    layer.on({
                        "click": function onUnionClick(e) {
                            var unionCode = feature.properties[adminCode + "_code"];
                            if (e.latlng) {

                                var clkPos = e.latlng;

                                set_location_data(unionCode, "", clkPos);

                                add_marker(clkPos, "red", unionCode, "");

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

            if (filterValue && feature.properties[adminCode + "_code"] == filterValue) {

                layer.className = "focused";
                layer.setStyle(focusStyle);

                map.fitBounds(layer.getBounds());
                //return;
            }
        },
        filter: function (feature, layer) {
            console.log("c: "+adminCode);
            return filterValue ? setMapFilter(feature, filterField, filterValue) : true;
        }
    });

    $.getJSON(adminLayerPath, function (adminLayerInfo) {
        if (!adminLayerInfo) return;

        adminLayer.addData(adminLayerInfo);
    }).done(function (e) {
        mapLayers["admin_" + adminCode] = { layer: adminLayer, label: adminLabels };

        map.addLayer(mapLayers["admin_" + adminCode].layer);

        if (!filterValue && (adminCode == "upaz" || adminCode == "union")) {
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

        if (feature.properties[adminCode + "_code"]) {
            switch (adminCode) {
                case "div":
                    var divCode = feature.properties[adminCode + "_code"];
                    add_admin_boundary("dist", true, divCode, "div_code");

                    layer.className = "focused";
                    layer.setStyle(focusStyle);

                    map.fitBounds(layer.getBounds());
                    break;

                case "dist":
                    var distCode = feature.properties[adminCode + "_code"];
                    add_admin_boundary("upaz", true, distCode, "dist_code");

                    layer.className = "focused";
                    layer.setStyle(focusStyle);

                    map.fitBounds(layer.getBounds());
                    break;

                case "upaz":
                    var upazCode = feature.properties[adminCode + "_code"];
                    add_admin_boundary("union", true, upazCode, "upaz_code");

                    layer.className = "focused";
                    layer.setStyle(focusStyle);

                    map.fitBounds(layer.getBounds());
                    break;

                default:
                    break;
            }
        }

    });


    adminLabels.addLayer(labelInfo);

    return;
}


function setMapFilter(feature, filterField, filterValue) {
    //console.log(adminCode);
    console.log(filterField);
    console.log(filterValue);
    console.log(feature.properties[filterField]);
    console.log(feature);

    if (!feature || !feature.properties[filterField] || feature.properties[filterField] != filterValue)
        return false;
    else
        return true;
}

