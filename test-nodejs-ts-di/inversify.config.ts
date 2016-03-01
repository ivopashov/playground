/// <reference path="./node_modules/inversify/type_definitions/inversify-global.d.ts" />
///<reference path="./source/interfaces.d.ts"/>

import inversify = require('inversify');
import Run = require('./source/services/Run')
import Jump = require('./source/services/Jump')   
import Athlete = require('./source/services/Athlete')      
  
export class IoC {
    private kernel : inversify.Kernel;
    constructor(){
        this.kernel = new inversify.Kernel(); 
        this.kernel.bind(new inversify.TypeBinding<RunInterface>("RunInterface", <any>Run));
        this.kernel.bind(new inversify.TypeBinding<JumpInterface>("JumpInterface", <any>Jump));
        this.kernel.bind(new inversify.TypeBinding<AthleteInterface>("AthleteInterface", <any>Athlete));
    }
    
    getAthlete() : AthleteInterface {
        return this.kernel.resolve<AthleteInterface>("Athlete");
    }
}  

