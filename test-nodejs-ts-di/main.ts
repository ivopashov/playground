import ioc = require('./inversify.config');

var result = <AthleteInterface>ioc.resolve("AthleteInterface");
result.saySports();