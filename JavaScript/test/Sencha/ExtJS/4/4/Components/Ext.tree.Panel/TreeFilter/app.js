Ext.application({
    name: 'treeFilterDemo',
    appFolder: 'app',

    requires: [  'Ext.form.Panel','Ext.container.Viewport',
                 'Ext.tree.Panel','Ext.layout.container.Border'
             ],
     setnode:function(tree){
		var node = {text:'', qtip:'',expanded:true, leaf:false, children:[]};
		
		var node1_1 = {text:'apple_1', qtip:'apple_1',expanded:true, leaf:true, children:[]};
		var node1_2 = {text:'apple_2', qtip:'apple_2',expanded:true, leaf:true, children:[]};
		var node1 = {text:'apple', qtip:'apple,apple_1,apple_2',expanded:true, leaf:false, children:[node1_1,node1_2]};
		var node2_1 = {text:'apricoat_1', qtip:'apricoat_1',expanded:true, leaf:true, children:[]};
		var node2_2 = {text:'apricoat_2', qtip:'apricoat_2',expanded:true, leaf:true, children:[]};
		var node2 = {text:'apricoat', qtip:'apricoat,apricoat_1,apricoat_2',expanded:true, leaf:false, children:[node2_1,node2_2]};
		node.children = [node1,node2];
		tree.setRootNode(node);
	},

    launch: function() {
		var setNodeFn = this.setnode;
		var tree =  Ext.create('Ext.tree.Panel', {
	    	myRootNodes:[],
	        region:'center',
	        hideHeaders: true,
	        rootVisible: false,
	        expandedNodes:[],
	         viewConfig: {
	            plugins: {
	                ptype: 'treeviewdragdrop',
	                appendOnly: true
	            }
	        },
	        height: 350,
	        width: 400,
		});
		var textField = {xtype:'textfield',
            	prompt:'serach', 
            	name: 'name',
            	region:'north',
            	value:'Type filter text',
            	enableKeyEvents:true,
            	listeners:{
                    focus:{fn:function (view, record, item, index, even) {
            	   this.setValue("");
            

                    }},
                    keyup:{
	                    	fn:function(view, record, item, index, even){
	                    	var txt= this;
	                    	setNodeFn(tree);
	                    	var removeArray = [];
	                    	var i=0;
							tree.getRootNode().cascadeBy(function() { // descends into child nodes
							   if(!(this.data.qtip.indexOf(txt.getValue())>-1)) {//Now do the actual filtering
								console.log("remove");
								removeArray[i] = this;//cannot call this.remove() here as cascadeBy() tens to traverse all the nodes and if node is removed it gives error
								i++;
							   }
							   
							});
							for(var j=0;j<i;j++) {
								removeArray[j].remove();//do actual removing, but unforunately once removed,,there is not a easy way to add back to same location so , here i simply regenrate whole tree again at line 53 : setnode(tree)
							
							}
                    	}
                    }
               			
                 }
               };
		this.setnode(tree);
        Ext.create('Ext.container.Viewport', {

            items: [
textField,tree
            ]
        });


    }
});