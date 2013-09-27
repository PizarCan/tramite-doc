function popup(title, ancho, alto, cargafuncion, botonfuncion, cerrar, modal) {
    //Ramdom del 1 al 1000//
    var a = 1;
    var b = 1000;
    var randomnumber = (a + Math.floor(Math.random() * b));
    var Botones = []; //Array
    var arrfunbot = [];
    var funbot = '';
    var funcionesCerrar = '';

    if (modal != false) modal = true;

    if (cerrar) {
        if (cerrar.funcerr) {
            jQuery.each(cerrar.funcerr,
			    function (e, funcerr) {
			        funcionesCerrar = funcionesCerrar + funcerr + "(";
			        if (cerrar.fvarc) {
			            jQuery.each(cerrar.fvarc,
			            //-- Por cara Articulo recorrido
			        		function (i, fvarc) {
			        		    if (fvarc) {
			        		        if (i == '0') funcionesCerrar = funcionesCerrar + "'" + fvarc + "'";
			        		        else funcionesCerrar = funcionesCerrar + ",'" + fvarc + "'";
			        		    } else msgbox('Validación', 'Variable de función cerrar esta Vacia', 'error');
			        		}
			            );
			        }
			        funcionesCerrar = funcionesCerrar + "); ";
			    }
		    );
        } else {
            msgbox('Verificar', 'No envies el parametro de función cerrar si no vas enviar la función', 'error');
            return false;
        }
    }

    if (botonfuncion != '' && botonfuncion != null) {
        if (botonfuncion.boton != '' && botonfuncion.boton != null) {
            jQuery.each(botonfuncion.boton,
			    function (e, boton) {
			        if (botonfuncion.boton != '') {
			            var jsonbotfun = 'botonfuncion.botfun' + e;
			            jsonbotfun = eval(jsonbotfun);
			            if (jsonbotfun != '' && jsonbotfun != null) {
			                jQuery.each(jsonbotfun,
			        		    function (i, jsonbotfun) {
			        		        if (jsonbotfun != '') {
			        		            funbot = jsonbotfun + '(';
			        		            var jsonrep = 'botonfuncion.fvars' + e;
			        		            jsonrep = eval(jsonrep);
			        		            if (jsonrep != '' && jsonrep != null) {
			        		                jQuery.each(jsonrep,
			        		                    function (j, jsonrep) {
			        		                        //if (jsonrep) {
			        		                        if (j == '0') funbot = funbot + "'" + jsonrep + "'";
			        		                        else funbot = funbot + ",'" + jsonrep + "'";
			        		                        //} else msgbox('Validación', 'Variable Vacia', 'error');
			        		                    }
			                                );
			        		            }
			        		            funbot = funbot + ')'
			        		            arrfunbot.push(funbot);
			        		            Botones.push({
			        		                text: boton,
			        		                click: function () { if (eval(arrfunbot[e])) $(this).dialog("close"); }
			        		            })
			        		        } else msgbox('Validación', 'No se especificado funcion del boton', 'error');
			        		    }
			                );
			            }
			        } else msgbox('Validación', 'No se especificado el nombre del boton', 'error');
			    }
		    );
            //msgbox('', funbot, 'alert');
            Botones.push({
                text: "Cerrar",
                click: function () { $(this).dialog("close"); }
            });
            //msgbox('', Botones.toSource(), 'alert');
        } else {
            msgbox('Verificar', 'No envies el parametro si no vas enviar la función', 'error');
        }
    } else {
        Botones = [{
            text: "Cerrar",
            click: function () { $(this).dialog("close"); }
        }];
    }

    $(function () {
        $('body').append('<div id="popup' + randomnumber + '" class="randompopup" title="' + title + '"></div>');
        $('#popup' + randomnumber).dialog({
            autoOpen: true,
            resizable: false,
            width: ancho,
            height: alto,
            modal: modal,
            buttons: Botones,
            close: function () {
                if (funcionesCerrar) eval(funcionesCerrar);
                $('#popup' + randomnumber).remove();
            }
        });
    });

    var funciones = '';
    if (cargafuncion != '' && cargafuncion != null) {
        if (cargafuncion.funcion != '' && cargafuncion.funcion != null) {
            jQuery.each(cargafuncion.funcion,
			    function (e, funcion) {
			        if (e == 0) {
			            funciones = funcion + "('popup" + randomnumber + "'";
			            if (cargafuncion.fvars != '' && cargafuncion.fvars != null) {
			                jQuery.each(cargafuncion.fvars,
			                //-- Por cara Articulo recorrido
			        		    function (i, fvars) {
			        		        funciones = funciones + ",'" + fvars + "'";
			        		    }
			                );
			            }
			        } else {
			            funciones = funciones + funcion + "(";
			            var jsfvars = 'cargafuncion.fvars' + e;
			            jsfvars = eval(jsfvars);
			            if (jsfvars != '' && jsfvars != null) {
			                jQuery.each(jsfvars,
			        		    function (j, jsfvars) {
			        		        if (j == 0) funciones = funciones + "'" + jsfvars + "'";
			        		        else funciones = funciones + ",'" + jsfvars + "'";
			        		    }
			                );
			            }
			        }
			        funciones = funciones + "); ";
			    }
		    );
        } else {
            msgbox('Verificar', 'No envies el parametro si no vas enviar la función', 'error');
        }
        eval(funciones);
    } else {
        msgbox('Alerta', 'No se especific&oacute; el nombre de la funci&oacute;n que debe cargar en el PopUP', 'error')
    }
};

function popupImprimir(titulo, variables, url) {
    if (!url) url = '/reportes.aspx';
    var pui = new Object;
    pui.funcion = new Array();
    pui.funcion[0] = 'cargaurl';
    pui.fvars = new Array();
    pui.fvars[0] = '/contenedoriframe.aspx';
    pui.fvars[1] = url;
    pui.fvars[2] = '99%';
    pui.fvars[3] = '99%';
    pui.fvars[4] = variables;

    popup(titulo, '900', '600', pui);
};

function cargaurl(contenedor, iframe, url, width, height, cadenavariables) {
    if (!width) width = '100%';
    if (!height) height = '550px';
    var rnd = Math.random() * 11;
    url = url + '?' + rnd;
    var str = 'url=' + url + '&width=' + width + '&height=' + height;
    if (cadenavariables) str = str + '&cadenavariables=' + cadenavariables;
    str = str + '&rnd=' + rnd;
    $.ajax({
        beforeSend: function () { process('open'); },
        type: 'post',
        url: iframe,
        data: str,
        success: function (response) {
            $('#' + contenedor).html(response);
        },
        complete: function () {
            process('close');
        }
    });
};

function process(modo, msg) {
    $(function () {
        if (modo == 'open') {
            if (!msg) msg = ' Espere un momento por favor...';
            $('body').append('<div id="process"><div style="float:left"><img src="/css/images/219.gif" width="25" height="25"></div><div style="inherit:left;padding:0 0 0 30px">' + msg + '</div></div>');

            $('#process').dialog({
                modal: true,
                resizable: false,
                height: 80,
                width: 350
            });
            $('#process').siblings('div.ui-dialog-titlebar').remove();
        } else {
            $('#process').remove();
        }
    });
};

function progressbar(contenedor, msg) {
    if (!msg) msg = '';
    $("#" + contenedor).html("<img src='/css/images/219.gif'/>" + msg);
}

function Ra_LimpiarDiv(division) {
    //$("#" + division).html("");
    var myDivisiones = division.split(",");
    for (var i = 0; i < myDivisiones.length; i++) {
        $("#" + myDivisiones[i]).html("");
    }
};