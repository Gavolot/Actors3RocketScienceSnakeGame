using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class LayerGameSnake : Layer<LayerGameSnake>{
        protected override void Setup(){
            Add<ProcessorInitPosition>();
            Add<ProcessorInitDir>();
            Add<ProcessorReposition>();

            Add<ProcessorStartFrame>();
            

            Add<ProcessorInputDir>();
            Add<ProcessorInputCantMoveCheck>();

            Add<ProcessorDepthSorting>();
            
            Add<ProcessorTickMoveToDir>();
            Add<ProcessorNewBodyCell>();
            Add<ProcessorEndFrame>();
        }
        protected override void OnLayerDestroy(){

        }
    }
}