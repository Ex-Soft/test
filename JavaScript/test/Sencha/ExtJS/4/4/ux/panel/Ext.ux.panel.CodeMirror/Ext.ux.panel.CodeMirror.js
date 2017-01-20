/*global Ext,  JSLINT, CodeMirror  */

/**
 * @class Ext.ux.panel.CodeMirror
 * @extends Ext.Panel
 * Converts a panel into a code mirror editor with toolbar
 * @constructor
 * 
 * @author Dan Ungureanu - ungureanu.web@gmail.com / http://www.devweb.ro
 * @version 0.1
 */

 // Define a set of code type configurations
Ext.ns('Ext.ux.panel.CodeMirrorConfig');
Ext.apply(Ext.ux.panel.CodeMirrorConfig, {
    cssPath: "/Scripts/ExtJs/codemirror/CodeMirror-2.0/css/",
    jsPath: "/Scripts/ExtJs/codemirror/CodeMirror-2.0/mode/"
});




Ext.ns('Ext.ux.panel.CodeMirror');
Ext.define('Ext.ux.panel.CodeMirror', {
    extend: 'Ext.Panel',
    alias: 'widget.uxCodeMirrorPanel',
    sourceCode: '/* Default code */',
    initComponent: function() {
        // this property is used to determine if the source content changes
        if (this.sourceId!=null)
        {
        	this.sourceCode = Ext.get(this.sourceId).getValue();
        }
        this.contentChanged = false;
        var oThis = this;
        this.debugWindow = new Ext.Window({
            title: 'Debug',
            width: 500,
            layout: 'border',
            closeAction: 'hide',
            height: 160,
            items: [new Ext.grid.GridPanel({
                layout: 'fit',
                region: 'center',
                border: false,
                listeners: {
                    rowclick: function(grid) {
                        var oData = grid.getSelectionModel().getSelected().data;
                        oThis.codeMirrorEditor.jumpToLine(oData.line);
                    }
                },
                store: new Ext.data.ArrayStore({
                    fields: [{
                        name: 'line'
                    }, {
                        name: 'character'
                    }, {
                        name: 'reason'
                    }]
                }),
                columns: [{
                    id: 'line',
                    header: 'Line',
                    width: 60,
                    sortable: true,
                    dataIndex: 'line'
                }, {
                    id: 'character',
                    header: 'Character',
                    width: 60,
                    sortable: true,
                    dataIndex: 'character'
                }, {
                    header: 'Description',
                    width: 240,
                    sortable: true,
                    dataIndex: 'reason'
                }],
                stripeRows: true
            })]
        });
        
        Ext.apply(this, {
            items: [{
                xtype: 'textarea',
                readOnly: false,
                hidden: false,
                inputId: this.setId,
                value: this.sourceCode
                
                
            }],
            tbar: [{
                text: 'Quick Save',
                iconCls: 'icoSaveFile',
                handler: this.triggerOnSave,
                scope: this
            }, {
                text: 'Undo',
                iconCls: 'icoUndo',
                handler: function() {
                    this.codeMirrorEditor.undo();
                },
                scope: this
            }, {
                text: 'Redo',
                iconCls: 'icoRedo',
                handler: function() {
                    this.codeMirrorEditor.redo();
                },
                scope: this
            }]
        });
        
        Ext.ux.panel.CodeMirror.superclass.initComponent.apply(this, arguments);
    },
    
    triggerOnSave: function(){
        this.setTitleClass(true);
        var sNewCode = this.codeMirrorEditor.getValue();
        
        //Ext.state.Manager.set("edcmr_"+this.itemId+'_lnmbr', this.codeMirrorEditor.currentLine());
        
        this.oldSourceCode = sNewCode;
        this.onSave(arguments[0] || false);
    },
    
    onRender: function() {
        this.oldSourceCode = this.sourceCode;
        Ext.ux.panel.CodeMirror.superclass.onRender.apply(this, arguments);
        // trigger editor on afterlayout
        this.on('afterlayout', this.triggerCodeEditor, this, {
            single: true
        });
        
    },
    
    /** @private */
    triggerCodeEditor: function() {
        //this.codeMirrorEditor;
        var oThis = this;

        var oCmp = this.items.items[0];//this.findParentByType('textarea')[0];
        var editorConfig = Ext.applyIf(this.codeMirror || {}, {
           height: "100%",
           width: "100%",
           mode: this.parser,
           lineNumbers: true,
           textWrapping: false,
           content: oCmp.getValue(),
           indentUnit: 4,
           tabMode: 'shift',
           readOnly: oCmp.readOnly,
           path: Ext.ux.panel.CodeMirrorConfig.jsPath,
           autoMatchParens: true,
           initCallback: function(editor) {
               editor.win.document.body.lastChild.scrollIntoView();
               try {
                   var iLineNmbr = ((Ext.state.Manager.get("edcmr_" + oThis.itemId + '_lnmbr') !== undefined) ? Ext.state.Manager.get("edcmr_" + oThis.itemId + '_lnmbr') : 1);
                   //console.log(iLineNmbr);
                   editor.jumpToLine(iLineNmbr);
               }catch(e){
                   //console.error(e);
               }
           }
       });
				function forEach(array, action) {
			    for (var i = 0; i < array.length; i++)
			      action(array[i]);
			  }
        var sParserType = oThis.parser || 'defo';
     
        this.codeMirrorEditor = new CodeMirror.fromTextArea( document.getElementById(this.setId), editorConfig); //editorConfig
        

    },
    
    setTitleClass: function(){
        //var tabEl = Ext.get(this.ownerCt.getTabEl( this ));
        if(arguments[0] === true){// remove class
            //tabEl.removeClass( "tab-changes" );
            this.contentChanged = false;
        }else{//add class
            //tabEl.addClass( "tab-changes" );
            this.contentChanged = true;
        }
    }
});

