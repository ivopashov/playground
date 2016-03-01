/// <reference path="../../node_modules/inversify/type_definitions/inversify-global.d.ts" />
/// <reference path="../interfaces.d.ts"/>

import inversify = require('inversify');

@inversify.Inject("RunInterface","JumpInterface")
export class Athlete implements AthleteInterface{
    public runAction : RunInterface;
    public jumpAction : JumpInterface;
    
    counstructor(RunInterface:RunInterface, JumpInterface:JumpInterface){
        this.runAction = RunInterface;
        this.jumpAction = JumpInterface;
    }
    
    saySports(){
        console.log("I can: " + this.jumpAction.jump() + " and i can "+ this.runAction.run());
    }
}