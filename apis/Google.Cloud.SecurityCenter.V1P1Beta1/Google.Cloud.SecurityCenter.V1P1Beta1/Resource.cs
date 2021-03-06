// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/cloud/securitycenter/v1p1beta1/resource.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Cloud.SecurityCenter.V1P1Beta1 {

  /// <summary>Holder for reflection information generated from google/cloud/securitycenter/v1p1beta1/resource.proto</summary>
  public static partial class ResourceReflection {

    #region Descriptor
    /// <summary>File descriptor for google/cloud/securitycenter/v1p1beta1/resource.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ResourceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjRnb29nbGUvY2xvdWQvc2VjdXJpdHljZW50ZXIvdjFwMWJldGExL3Jlc291",
            "cmNlLnByb3RvEiVnb29nbGUuY2xvdWQuc2VjdXJpdHljZW50ZXIudjFwMWJl",
            "dGExGhxnb29nbGUvYXBpL2Fubm90YXRpb25zLnByb3RvInQKCFJlc291cmNl",
            "EgwKBG5hbWUYASABKAkSDwoHcHJvamVjdBgCIAEoCRIcChRwcm9qZWN0X2Rp",
            "c3BsYXlfbmFtZRgDIAEoCRIOCgZwYXJlbnQYBCABKAkSGwoTcGFyZW50X2Rp",
            "c3BsYXlfbmFtZRgFIAEoCUKMAgopY29tLmdvb2dsZS5jbG91ZC5zZWN1cml0",
            "eWNlbnRlci52MXAxYmV0YTFCDVJlc291cmNlUHJvdG9QAVpTZ29vZ2xlLmdv",
            "bGFuZy5vcmcvZ2VucHJvdG8vZ29vZ2xlYXBpcy9jbG91ZC9zZWN1cml0eWNl",
            "bnRlci92MXAxYmV0YTE7c2VjdXJpdHljZW50ZXKqAiVHb29nbGUuQ2xvdWQu",
            "U2VjdXJpdHlDZW50ZXIuVjFQMUJldGExygIlR29vZ2xlXENsb3VkXFNlY3Vy",
            "aXR5Q2VudGVyXFYxcDFiZXRhMeoCKEdvb2dsZTo6Q2xvdWQ6OlNlY3VyaXR5",
            "Q2VudGVyOjpWMXAxYmV0YTFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.SecurityCenter.V1P1Beta1.Resource), global::Google.Cloud.SecurityCenter.V1P1Beta1.Resource.Parser, new[]{ "Name", "Project", "ProjectDisplayName", "Parent", "ParentDisplayName" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Information related to the Google Cloud resource.
  /// </summary>
  public sealed partial class Resource : pb::IMessage<Resource> {
    private static readonly pb::MessageParser<Resource> _parser = new pb::MessageParser<Resource>(() => new Resource());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Resource> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Cloud.SecurityCenter.V1P1Beta1.ResourceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Resource() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Resource(Resource other) : this() {
      name_ = other.name_;
      project_ = other.project_;
      projectDisplayName_ = other.projectDisplayName_;
      parent_ = other.parent_;
      parentDisplayName_ = other.parentDisplayName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Resource Clone() {
      return new Resource(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    /// <summary>
    /// The full resource name of the resource. See:
    /// https://cloud.google.com/apis/design/resource_names#full_resource_name
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "project" field.</summary>
    public const int ProjectFieldNumber = 2;
    private string project_ = "";
    /// <summary>
    /// The full resource name of project that the resource belongs to.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Project {
      get { return project_; }
      set {
        project_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "project_display_name" field.</summary>
    public const int ProjectDisplayNameFieldNumber = 3;
    private string projectDisplayName_ = "";
    /// <summary>
    /// The human readable name of project that the resource belongs to.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ProjectDisplayName {
      get { return projectDisplayName_; }
      set {
        projectDisplayName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "parent" field.</summary>
    public const int ParentFieldNumber = 4;
    private string parent_ = "";
    /// <summary>
    /// The full resource name of resource's parent.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Parent {
      get { return parent_; }
      set {
        parent_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "parent_display_name" field.</summary>
    public const int ParentDisplayNameFieldNumber = 5;
    private string parentDisplayName_ = "";
    /// <summary>
    /// The human readable name of resource's parent.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ParentDisplayName {
      get { return parentDisplayName_; }
      set {
        parentDisplayName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Resource);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Resource other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Project != other.Project) return false;
      if (ProjectDisplayName != other.ProjectDisplayName) return false;
      if (Parent != other.Parent) return false;
      if (ParentDisplayName != other.ParentDisplayName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Project.Length != 0) hash ^= Project.GetHashCode();
      if (ProjectDisplayName.Length != 0) hash ^= ProjectDisplayName.GetHashCode();
      if (Parent.Length != 0) hash ^= Parent.GetHashCode();
      if (ParentDisplayName.Length != 0) hash ^= ParentDisplayName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Project.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Project);
      }
      if (ProjectDisplayName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ProjectDisplayName);
      }
      if (Parent.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Parent);
      }
      if (ParentDisplayName.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ParentDisplayName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Project.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Project);
      }
      if (ProjectDisplayName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ProjectDisplayName);
      }
      if (Parent.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Parent);
      }
      if (ParentDisplayName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ParentDisplayName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Resource other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Project.Length != 0) {
        Project = other.Project;
      }
      if (other.ProjectDisplayName.Length != 0) {
        ProjectDisplayName = other.ProjectDisplayName;
      }
      if (other.Parent.Length != 0) {
        Parent = other.Parent;
      }
      if (other.ParentDisplayName.Length != 0) {
        ParentDisplayName = other.ParentDisplayName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            Project = input.ReadString();
            break;
          }
          case 26: {
            ProjectDisplayName = input.ReadString();
            break;
          }
          case 34: {
            Parent = input.ReadString();
            break;
          }
          case 42: {
            ParentDisplayName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
