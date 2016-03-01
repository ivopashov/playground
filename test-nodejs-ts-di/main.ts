/// <reference path="./node_modules/inversify/type_definitions/inversify-global.d.ts" />
/// <reference path="./source/interfaces.d.ts"/>
declare function require(name:string);
import ioc = require('./inversify.config');

var container = new ioc.IoC();
var athlete = container.getAthlete();
athlete.saySports();