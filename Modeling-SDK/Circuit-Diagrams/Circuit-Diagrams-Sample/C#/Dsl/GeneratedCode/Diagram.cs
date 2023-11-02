﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

[module: global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "type", Target = "Microsoft.Example.Circuits.ComponentDiagram")]

namespace Microsoft.Example.Circuits
{
	/// <summary>
	/// Double-derived base class for DomainClass ComponentDiagram
	/// </summary>
	[DslDesign::DisplayNameResource("Microsoft.Example.Circuits.ComponentDiagram.DisplayName", typeof(global::Microsoft.Example.Circuits.CircuitsDomainModel), "Microsoft.Example.Circuits.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Microsoft.Example.Circuits.ComponentDiagram.Description", typeof(global::Microsoft.Example.Circuits.CircuitsDomainModel), "Microsoft.Example.Circuits.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Microsoft.Example.Circuits.CircuitsDomainModel))]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("6d81a7a1-1943-48f8-8d31-f7ccd273b1c8")]
	public abstract partial class ComponentDiagramBase : DslDiagrams::Diagram
	{
		#region Diagram boilerplate
		private static DslDiagrams::StyleSet classStyleSet;
		private static global::System.Collections.Generic.IList<DslDiagrams::ShapeField> shapeFields;
		/// <summary>
		/// Per-class style set for this shape.
		/// </summary>
		protected override DslDiagrams::StyleSet ClassStyleSet
		{
			get
			{
				if (classStyleSet == null)
				{
					classStyleSet = CreateClassStyleSet();
				}
				return classStyleSet;
			}
		}
		
		/// <summary>
		/// Per-class ShapeFields for this shape
		/// </summary>
		public override global::System.Collections.Generic.IList<DslDiagrams::ShapeField> ShapeFields
		{
			get
			{
				if (shapeFields == null)
				{
					shapeFields = CreateShapeFields();
				}
				return shapeFields;
			}
		}
		#endregion
		#region Toolbox filters
		private static global::System.ComponentModel.ToolboxItemFilterAttribute[] toolboxFilters = new global::System.ComponentModel.ToolboxItemFilterAttribute[] {
					new global::System.ComponentModel.ToolboxItemFilterAttribute(global::Microsoft.Example.Circuits.CircuitsToolboxHelperBase.ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) };
		
		/// <summary>
		/// Toolbox item filter attributes for this diagram.
		/// </summary>
		public override global::System.Collections.ICollection TargetToolboxItemFilterAttributes
		{
			get
			{
				return toolboxFilters;
			}
		}
		#endregion
		#region Auto-placement
		/// <summary>
		/// Indicate that child shapes should added through view fixup should be placed automatically.
		/// </summary>
		public override bool ShouldAutoPlaceChildShapes
		{
			get
			{
				return true;
			}
		}
		#endregion
		#region Port shape support
		/// <summary>
		/// Indicates whether the diagram contains any ports.  Hit testing will not
		/// check for ports if this is false.
		/// </summary>
		public override bool SupportsPorts
		{
			get
			{
				return true;
			}
		}
		#endregion
		#region Shape mapping
		/// <summary>
		/// Called during view fixup to ask the parent whether a shape should be created for the given child element.
		/// </summary>
		/// <remarks>
		/// Always return true, since we assume there is only one diagram per model file for DSL scenarios.
		/// </remarks>
		protected override bool ShouldAddShapeForElement(DslModeling::ModelElement element)
		{
			return true;
		}
		
		/// <summary>
		/// Called during view fixup to configure the given child element, after it has been created.
		/// </summary>
		/// <remarks>
		/// Custom code for choosing the shapes attached to either end of a connector is called from here.
		/// </remarks>
		protected override void OnChildConfiguring(DslDiagrams::ShapeElement child, bool createdDuringViewFixup)
		{
			DslDiagrams::NodeShape sourceShape;
			DslDiagrams::NodeShape targetShape;
			DslDiagrams::BinaryLinkShape connector = child as DslDiagrams::BinaryLinkShape;
			if(connector == null)
			{
				base.OnChildConfiguring(child, createdDuringViewFixup);
				return;
			}
			this.GetSourceAndTargetForConnector(connector, out sourceShape, out targetShape);
			
			global::System.Diagnostics.Debug.Assert(sourceShape != null && targetShape != null, "Unable to find source and target shapes for connector.");
			connector.Connect(sourceShape, targetShape);
		}
		
		/// <summary>
		/// helper method to find the shapes for either end of a connector, including calling the user's custom code
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		internal void GetSourceAndTargetForConnector(DslDiagrams::BinaryLinkShape connector, out DslDiagrams::NodeShape sourceShape, out DslDiagrams::NodeShape targetShape)
		{
			sourceShape = null;
			targetShape = null;
			
			if (sourceShape == null || targetShape == null)
			{
				DslDiagrams::NodeShape[] endShapes = GetEndShapesForConnector(connector);
				if(sourceShape == null)
				{
					sourceShape = endShapes[0];
				}
				if(targetShape == null)
				{
					targetShape = endShapes[1];
				}
			}
		}
		
		/// <summary>
		/// Helper method to find shapes for either end of a connector by looking for shapes associated with either end of the relationship mapped to the connector.
		/// </summary>
		private DslDiagrams::NodeShape[] GetEndShapesForConnector(DslDiagrams::BinaryLinkShape connector)
		{
			DslModeling::ElementLink link = connector.ModelElement as DslModeling::ElementLink;
			DslDiagrams::NodeShape sourceShape = null, targetShape = null;
			if (link != null)
			{
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::ModelElement> linkedElements = link.LinkedElements;
				if (linkedElements.Count == 2)
				{
					DslDiagrams::Diagram currentDiagram = this.Diagram;
					DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[0]);
					foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
					{
						DslDiagrams::NodeShape shape = presentationElement as DslDiagrams::NodeShape;
						if (shape != null && shape.Diagram == currentDiagram)
						{
							sourceShape = shape;
							break;
						}
					}
					
					presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[1]);
					foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
					{
						DslDiagrams::NodeShape shape = presentationElement as DslDiagrams::NodeShape;
						if (shape != null && shape.Diagram == currentDiagram)
						{
							targetShape = shape;
							break;
						}
					}
		
				}
			}
			
			return new DslDiagrams::NodeShape[] { sourceShape, targetShape };
		}
		
		/// <summary>
		/// Creates a new shape for the given model element as part of view fixup
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification = "Generated code.")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
		protected override DslDiagrams::ShapeElement CreateChildShape(DslModeling::ModelElement element)
		{
			if(element is global::Microsoft.Example.Circuits.Resistor)
			{
				global::Microsoft.Example.Circuits.ResistorShape newShape = new global::Microsoft.Example.Circuits.ResistorShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.ComponentTerminal)
			{
				global::Microsoft.Example.Circuits.ComponentTerminalShape newShape = new global::Microsoft.Example.Circuits.ComponentTerminalShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.Capacitor)
			{
				global::Microsoft.Example.Circuits.CapacitorShape newShape = new global::Microsoft.Example.Circuits.CapacitorShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.Junction)
			{
				global::Microsoft.Example.Circuits.JunctionShape newShape = new global::Microsoft.Example.Circuits.JunctionShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.Transistor)
			{
				global::Microsoft.Example.Circuits.TransistorShape newShape = new global::Microsoft.Example.Circuits.TransistorShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.Comment)
			{
				global::Microsoft.Example.Circuits.CommentBoxShape newShape = new global::Microsoft.Example.Circuits.CommentBoxShape(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.Wire)
			{
				global::Microsoft.Example.Circuits.WireConnector newShape = new global::Microsoft.Example.Circuits.WireConnector(this.Partition);
				return newShape;
			}
			if(element is global::Microsoft.Example.Circuits.CommentsReferenceComponents)
			{
				global::Microsoft.Example.Circuits.CommentLink newShape = new global::Microsoft.Example.Circuits.CommentLink(this.Partition);
				return newShape;
			}
			return base.CreateChildShape(element);
		}
		#endregion
		#region Decorator mapping
		/// <summary>
		/// Initialize shape decorator mappings.  This is done here rather than in individual shapes because decorator maps
		/// are defined per diagram type rather than per shape type.
		/// </summary>
		protected override void InitializeShapeFields(global::System.Collections.Generic.IList<DslDiagrams::ShapeField> shapeFields)
		{
			base.InitializeShapeFields(shapeFields);
			global::Microsoft.Example.Circuits.ResistorShape.DecoratorsInitialized += ResistorShapeDecoratorMap.OnDecoratorsInitialized;
			global::Microsoft.Example.Circuits.JunctionShape.DecoratorsInitialized += JunctionShapeDecoratorMap.OnDecoratorsInitialized;
			global::Microsoft.Example.Circuits.TransistorShape.DecoratorsInitialized += TransistorShapeDecoratorMap.OnDecoratorsInitialized;
			global::Microsoft.Example.Circuits.CapacitorShape.DecoratorsInitialized += CapacitorShapeDecoratorMap.OnDecoratorsInitialized;
			global::Microsoft.Example.Circuits.CommentBoxShape.DecoratorsInitialized += CommentBoxShapeDecoratorMap.OnDecoratorsInitialized;
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for ComponentShape.
		/// </summary>
		internal static partial class ComponentShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for ComponentShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for ResistorShape.
		/// </summary>
		internal static partial class ResistorShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for ResistorShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				ComponentShapeDecoratorMap.OnDecoratorsInitialized(sender, e);
				
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.NamedElement.NameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for JunctionShape.
		/// </summary>
		internal static partial class JunctionShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for JunctionShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				ComponentShapeDecoratorMap.OnDecoratorsInitialized(sender, e);
				
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.NamedElement.NameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for TransistorShape.
		/// </summary>
		internal static partial class TransistorShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for TransistorShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				ComponentShapeDecoratorMap.OnDecoratorsInitialized(sender, e);
				
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.NamedElement.NameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
		
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.Component.PolarityDomainPropertyId);
				propertyInfo.FilteringValues.Add("False");
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NPNImage").AssociateVisibilityWith(shape.Store, propertyInfo);
		
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.Component.PolarityDomainPropertyId);
				propertyInfo.FilteringValues.Add("True");
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "PNPImage").AssociateVisibilityWith(shape.Store, propertyInfo);
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for CapacitorShape.
		/// </summary>
		internal static partial class CapacitorShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for CapacitorShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				ComponentShapeDecoratorMap.OnDecoratorsInitialized(sender, e);
				
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.NamedElement.NameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
		
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.Capacitor.IsPolarDomainPropertyId);
				propertyInfo.FilteringValues.Add("False");
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NonPolarImage").AssociateVisibilityWith(shape.Store, propertyInfo);
		
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.Capacitor.IsPolarDomainPropertyId);
				propertyInfo.FilteringValues.Add("True");
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "PolarImage").AssociateVisibilityWith(shape.Store, propertyInfo);
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for CommentBoxShape.
		/// </summary>
		internal static partial class CommentBoxShapeDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for CommentBoxShape.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::Microsoft.Example.Circuits.Comment.TextDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "Comment").AssociateValueWith(shape.Store, propertyInfo);
			}
		}
		
		#endregion
		
		#region Connect actions
		private bool changingMouseAction;
		private global::Microsoft.Example.Circuits.WireConnectAction wireConnectAction;
		private global::Microsoft.Example.Circuits.CommentConnectorConnectAction commentConnectorConnectAction;
		/// <summary>
		/// Virtual method to provide a filter when to select the mouse action
		/// </summary>
		/// <param name="activeView">Currently active view</param>
		/// <param name="filter">filter string used to filter the toolbox items</param>
		protected virtual bool SelectedToolboxItemSupportsFilterString(DslDiagrams::DiagramView activeView, string filter)
		{
			return activeView.SelectedToolboxItemSupportsFilterString(filter);
		}
		/// <summary>
		/// Override to provide the right mouse action when trying
		/// to create links on the diagram
		/// </summary>
		/// <param name="pointArgs"></param>
		public override void OnViewMouseEnter(DslDiagrams::DiagramPointEventArgs pointArgs)
		{
			if (pointArgs  == null) throw new global::System.ArgumentNullException("pointArgs");
		
			DslDiagrams::DiagramView activeView = this.ActiveDiagramView;
			if(activeView != null)
			{
				DslDiagrams::MouseAction action = null;
				if (SelectedToolboxItemSupportsFilterString(activeView, global::Microsoft.Example.Circuits.CircuitsToolboxHelper.WireFilterString))
				{
					if (this.wireConnectAction == null)
					{
						this.wireConnectAction = new global::Microsoft.Example.Circuits.WireConnectAction(this);
						this.wireConnectAction.MouseActionDeactivated += new DslDiagrams::MouseAction.MouseActionDeactivatedEventHandler(OnConnectActionDeactivated);
					}
					action = this.wireConnectAction;
				} 
				else if (SelectedToolboxItemSupportsFilterString(activeView, global::Microsoft.Example.Circuits.CircuitsToolboxHelper.CommentConnectorFilterString))
				{
					if (this.commentConnectorConnectAction == null)
					{
						this.commentConnectorConnectAction = new global::Microsoft.Example.Circuits.CommentConnectorConnectAction(this);
						this.commentConnectorConnectAction.MouseActionDeactivated += new DslDiagrams::MouseAction.MouseActionDeactivatedEventHandler(OnConnectActionDeactivated);
					}
					action = this.commentConnectorConnectAction;
				} 
				else
				{
					action = null;
				}
				
				if (pointArgs.DiagramClientView.ActiveMouseAction != action)
				{
					try
					{
						this.changingMouseAction = true;
						pointArgs.DiagramClientView.ActiveMouseAction = action;
					}
					finally
					{
						this.changingMouseAction = false;
					}
				}
			}
		}
		
		/// <summary>
		/// Snap toolbox selection back to regular pointer after using a custom connect action.
		/// </summary>
		private void OnConnectActionDeactivated(object sender, DslDiagrams::DiagramEventArgs e)
		{
			OnMouseActionDeactivated();
		}
		
		/// <summary>
		/// Overridable method to manage the mouse deactivation. The default implementation snap stoolbox selection back to regular pointer 
		/// after using a custom connect action.
		/// </summary>
		protected virtual void OnMouseActionDeactivated()
		{
			DslDiagrams::DiagramView activeView = this.ActiveDiagramView;
		
			if (activeView != null && activeView.Toolbox != null)
			{
				// If we're not changing mouse action due to changing toolbox selection change,
				// reset toolbox selection.
				if (!this.changingMouseAction)
				{
					activeView.Toolbox.SelectedToolboxItemUsed();
				}
			}
		}
		#endregion
		
		/// <summary>
		/// Dispose of connect actions.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					if(this.wireConnectAction != null)
					{
						this.wireConnectAction.Dispose();
						this.wireConnectAction = null;
					}
					if(this.commentConnectorConnectAction != null)
					{
						this.commentConnectorConnectAction.Dispose();
						this.commentConnectorConnectAction = null;
					}
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		#region Constructors, domain class Id
	
		/// <summary>
		/// ComponentDiagram domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x6d81a7a1, 0x1943, 0x48f8, 0x8d, 0x31, 0xf7, 0xcc, 0xd2, 0x73, 0xb1, 0xc8);
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected ComponentDiagramBase(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
	/// <summary>
	/// DomainClass ComponentDiagram
	/// </summary>
	[global::System.CLSCompliant(true)]
			
	public partial class ComponentDiagram : ComponentDiagramBase
	{
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ComponentDiagram(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ComponentDiagram(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
namespace Microsoft.Example.Circuits
{
	
		/// <summary>
		/// Double derived implementation for the rule that initiates view fixup when an element that has an associated shape is added to the model.
		/// This now enables the DSL author to everride the SkipFixUp() method 
		/// </summary>
		internal partial class FixUpDiagramBase : DslModeling::AddRule
		{
			protected virtual bool SkipFixup(DslModeling::ModelElement childElement)
			{
				return childElement.IsDeleted;
			}
		}
	
		/// <summary>
		/// Rule that initiates view fixup when an element that has an associated shape is added to the model. 
		/// </summary>
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Junction), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Transistor), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Capacitor), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Resistor), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.ComponentTerminal), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority + 1, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.CommentsReferenceComponents), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Wire), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Comment), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		internal sealed partial class FixUpDiagram : FixUpDiagramBase
		{
			[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
			public override void ElementAdded(DslModeling::ElementAddedEventArgs e)
			{
				if(e == null) throw new global::System.ArgumentNullException("e");
			
				DslModeling::ModelElement childElement = e.ModelElement;
				if (this.SkipFixup(childElement))
					return;
				DslModeling::ModelElement parentElement;
				if(childElement is DslModeling::ElementLink)
				{
					parentElement = GetParentForRelationship((DslModeling::ElementLink)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.Junction)
				{
					parentElement = GetParentForJunction((global::Microsoft.Example.Circuits.Junction)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.Transistor)
				{
					parentElement = GetParentForTransistor((global::Microsoft.Example.Circuits.Transistor)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.Capacitor)
				{
					parentElement = GetParentForCapacitor((global::Microsoft.Example.Circuits.Capacitor)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.Resistor)
				{
					parentElement = GetParentForResistor((global::Microsoft.Example.Circuits.Resistor)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.ComponentTerminal)
				{
					parentElement = GetParentForComponentTerminal((global::Microsoft.Example.Circuits.ComponentTerminal)childElement);
				} else
				if(childElement is global::Microsoft.Example.Circuits.Comment)
				{
					parentElement = GetParentForComment((global::Microsoft.Example.Circuits.Comment)childElement);
				} else
				{
					parentElement = null;
				}
				
				if(parentElement != null)
				{
					DslDiagrams::Diagram.FixUpDiagram(parentElement, childElement);
				}
			}
			public static global::Microsoft.Example.Circuits.Component GetParentForComponentTerminal( global::Microsoft.Example.Circuits.ComponentTerminal root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.Component result = root.Component;
				if ( result == null ) return null;
				return result;
			}
			public static global::Microsoft.Example.Circuits.ComponentModel GetParentForResistor( global::Microsoft.Example.Circuits.Component root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.ComponentModel result = root.ComponentModel;
				if ( result == null ) return null;
				return result;
			}
			public static global::Microsoft.Example.Circuits.ComponentModel GetParentForComment( global::Microsoft.Example.Circuits.Comment root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.ComponentModel result = root.ComponentModel;
				if ( result == null ) return null;
				return result;
			}
			public static global::Microsoft.Example.Circuits.ComponentModel GetParentForJunction( global::Microsoft.Example.Circuits.Junction root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.ComponentModel result = root.ComponentModel;
				if ( result == null ) return null;
				return result;
			}
			public static global::Microsoft.Example.Circuits.ComponentModel GetParentForTransistor( global::Microsoft.Example.Circuits.Component root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.ComponentModel result = root.ComponentModel;
				if ( result == null ) return null;
				return result;
			}
			public static global::Microsoft.Example.Circuits.ComponentModel GetParentForCapacitor( global::Microsoft.Example.Circuits.Component root )
			{
				// Segments 0 and 1
				global::Microsoft.Example.Circuits.ComponentModel result = root.ComponentModel;
				if ( result == null ) return null;
				return result;
			}
			private static DslModeling::ModelElement GetParentForRelationship(DslModeling::ElementLink elementLink)
			{
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::ModelElement> linkedElements = elementLink.LinkedElements;
	
				if (linkedElements.Count == 2)
				{
					DslDiagrams::ShapeElement sourceShape = linkedElements[0] as DslDiagrams::ShapeElement;
					DslDiagrams::ShapeElement targetShape = linkedElements[1] as DslDiagrams::ShapeElement;
	
					if(sourceShape == null)
					{
						DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[0]);
						foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
						{
							DslDiagrams::ShapeElement shape = presentationElement as DslDiagrams::ShapeElement;
							if (shape != null)
							{
								sourceShape = shape;
								break;
							}
						}
					}
					
					if(targetShape == null)
					{
						DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[1]);
						foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
						{
							DslDiagrams::ShapeElement shape = presentationElement as DslDiagrams::ShapeElement;
							if (shape != null)
							{
								targetShape = shape;
								break;
							}
						}
					}
					
					if(sourceShape == null || targetShape == null)
					{
						global::System.Diagnostics.Debug.Fail("Unable to find source and/or target shape for view fixup.");
						return null;
					}
	
					DslDiagrams::ShapeElement sourceParent = sourceShape.ParentShape;
					DslDiagrams::ShapeElement targetParent = targetShape.ParentShape;
	
					while (sourceParent != targetParent && sourceParent != null)
					{
						DslDiagrams::ShapeElement curParent = targetParent;
						while (sourceParent != curParent && curParent != null)
						{
							curParent = curParent.ParentShape;
						}
	
						if(sourceParent == curParent)
						{
							break;
						}
						else
						{
							sourceParent = sourceParent.ParentShape;
						}
					}
	
					while (sourceParent != null)
					{
						// ensure that the parent can parent connectors (i.e., a diagram or a swimlane).
						if(sourceParent is DslDiagrams::Diagram || sourceParent is DslDiagrams::SwimlaneShape)
						{
							break;
						}
						else
						{
							sourceParent = sourceParent.ParentShape;
						}
					}
	
					global::System.Diagnostics.Debug.Assert(sourceParent != null && sourceParent.ModelElement != null, "Unable to find common parent for view fixup.");
					return sourceParent.ModelElement;
				}
	
				return null;
			}
		}
		
	
		/// <summary>
		/// A rule which fires when data mapped to outer text decorators has changed,
		/// so we can update the decorator host's bounds.
		/// </summary>
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.NamedElement), InitiallyDisabled=true)]
		internal sealed class DecoratorPropertyChanged : DslModeling::ChangeRule
		{
			[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
			public override void ElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs e)
			{
				if(e == null) throw new global::System.ArgumentNullException("e");
				
				if (e.DomainProperty.Id == global::Microsoft.Example.Circuits.NamedElement.NameDomainPropertyId)
				{
					DslDiagrams::Decorator decorator = global::Microsoft.Example.Circuits.ResistorShape.FindResistorShapeDecorator("NameDecorator");
					if(decorator != null)
					{
						decorator.UpdateDecoratorHostShapes(e.ModelElement, global::Microsoft.Example.Circuits.Resistor.DomainClassId);
					}
					decorator = global::Microsoft.Example.Circuits.JunctionShape.FindJunctionShapeDecorator("NameDecorator");
					if(decorator != null)
					{
						decorator.UpdateDecoratorHostShapes(e.ModelElement, global::Microsoft.Example.Circuits.Junction.DomainClassId);
					}
					decorator = global::Microsoft.Example.Circuits.TransistorShape.FindTransistorShapeDecorator("NameDecorator");
					if(decorator != null)
					{
						decorator.UpdateDecoratorHostShapes(e.ModelElement, global::Microsoft.Example.Circuits.Transistor.DomainClassId);
					}
					decorator = global::Microsoft.Example.Circuits.CapacitorShape.FindCapacitorShapeDecorator("NameDecorator");
					if(decorator != null)
					{
						decorator.UpdateDecoratorHostShapes(e.ModelElement, global::Microsoft.Example.Circuits.Capacitor.DomainClassId);
					}
				}
			}
		}
	
		/// <summary>
		/// Reroute a connector when the role players of its underlying relationship change
		/// </summary>
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.Wire), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::Microsoft.Example.Circuits.CommentsReferenceComponents), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		internal sealed class ConnectorRolePlayerChanged : DslModeling::RolePlayerChangeRule
		{
			/// <summary>
			/// Reroute a connector when the role players of its underlying relationship change
			/// </summary>
			public override void RolePlayerChanged(DslModeling::RolePlayerChangedEventArgs e)
			{
				if (e == null) throw new global::System.ArgumentNullException("e");
	
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslDiagrams::PresentationViewsSubject> connectorLinks = DslDiagrams::PresentationViewsSubject.GetLinksToPresentation(e.ElementLink);
				foreach (DslDiagrams::PresentationViewsSubject connectorLink in connectorLinks)
				{
					// Fix up any binary link shapes attached to the element link.
					DslDiagrams::BinaryLinkShape linkShape = connectorLink.Presentation as DslDiagrams::BinaryLinkShape;
					if (linkShape != null)
					{
						global::Microsoft.Example.Circuits.ComponentDiagram diagram = linkShape.Diagram as global::Microsoft.Example.Circuits.ComponentDiagram;
						if (diagram != null)
						{
							if (e.NewRolePlayer != null)
							{
								DslDiagrams::NodeShape fromShape;
								DslDiagrams::NodeShape toShape;
								diagram.GetSourceAndTargetForConnector(linkShape, out fromShape, out toShape);
								if (fromShape != null && toShape != null)
								{
									if (!object.Equals(fromShape, linkShape.FromShape))
									{
										linkShape.FromShape = fromShape;
									}
									if (!object.Equals(linkShape.ToShape, toShape))
									{
										linkShape.ToShape = toShape;
									}
								}
								else
								{
									// delete the connector if we cannot find an appropriate target shape.
									linkShape.Delete();
								}
							}
							else
							{
								// delete the connector if the new role player is null.
								linkShape.Delete();
							}
						}
					}
				}
			}
		}
	}
