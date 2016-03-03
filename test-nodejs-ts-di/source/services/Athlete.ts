import inversify = require('inversify');

@inversify.Inject("RunInterface","JumpInterface")
class Athlete implements AthleteInterface{
    public runAction : RunInterface;
    public jumpAction : JumpInterface;
    
    constructor(RunInterface:RunInterface, JumpInterface:JumpInterface){
        this.runAction = RunInterface;
        this.jumpAction = JumpInterface;
    }
    
    saySports(){
        console.log("I can do two things:");
        this.jumpAction.jump();
        this.runAction.run();
    }
}

export = Athlete