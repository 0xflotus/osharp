// -----------------------------------------------------------------------
//  <copyright file="PropertyMetadata.cs" company="OSharp��Դ�Ŷ�">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>������</last-editor>
//  <last-date>2018-08-06 12:31</last-date>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using OSharp.Reflection;


namespace OSharp.CodeGeneration.Schema
{
    /// <summary>
    /// ����Ԫ����
    /// </summary>
    public class PropertyMetadata
    {
        /// <summary>
        /// ��ȡ������ ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������ ������������
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// ��ȡ������ ��ʾ����
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// ��ȡ������ ��������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��ȡ������ �Ƿ����
        /// </summary>
        public bool? IsRequired { get; set; }

        /// <summary>
        /// ��ȡ������ ��󳤶�
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// ��ȡ������ ��С����
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// ��ȡ������ ȡֵ��Χ
        /// </summary>
        public object[] Range { get; set; }

        /// <summary>
        /// ��ȡ������ ���ֵ
        /// </summary>
        public object Max { get; set; }

        /// <summary>
        /// ��ȡ������ ��Сֵ
        /// </summary>
        public object Min { get; set; }

        /// <summary>
        /// ��ȡ������ �Ƿ�ֵ���Ϳɿ�
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// ��ȡ������ �Ƿ�������
        /// </summary>
        public bool IsVirtual { get; set; }

        /// <summary>
        /// ��ȡ������ �Ƿ����
        /// </summary>
        public bool IsForeignKey { get; set; }

        /// <summary>
        /// ��ȡ������ ö��Ԫ����
        /// </summary>
        public EnumMetadata[] EnumMetadatas { get; set; }

        /// <summary>
        /// �Ƿ�����֤���� 
        /// </summary>
        public bool HasValidateAttribute()
        {
            return IsRequired.HasValue || MaxLength.HasValue || MinLength.HasValue || Range != null || Max != null || Min != null;
        }

        /// <summary>
        /// ��ȡ���Ա�ʾ���͵ļ����ͣ��� System.String ���� string
        /// </summary>
        public string ToSingleTypeName()
        {
            PropertyMetadata prop = this;
            string name = prop.TypeName;
            switch (prop.TypeName)
            {
                case "System.Byte":
                    name = "byte";
                    break;
                case "System.Int32":
                    name = "int";
                    break;
                case "System.Int64":
                    name = "long";
                    break;
                case "System.Decimal":
                    name = "decimal";
                    break;
                case "System.Single":
                    name = "float";
                    break;
                case "System.Double":
                    name = "double";
                    break;
                case "System.String":
                    name = "string";
                    break;
                case "System.Guid":
                    name = "Guid";
                    break;
                case "System.Boolean":
                    name = "bool";
                    break;
                case "System.DateTime":
                    name = "DateTime";
                    break;
            }
            if (prop.IsNullable)
            {
                name = name + "?";
            }
            return name;
        }

        /// <summary>
        /// ��ȡ���Ա�ʾ���͵�JS�����ַ���
        /// </summary>
        public string ToJsTypeName()
        {
            PropertyMetadata prop = this;
            string name = "object";
            switch (prop.TypeName)
            {
                case "System.Byte":
                case "System.Int32":
                case "System.Int64":
                case "System.Decimal":
                case "System.Single":
                case "System.Double":
                    name = "number";
                    break;
                case "System.String":
                case "System.Guid":
                    name = "string";
                    break;
                case "System.Boolean":
                    name = "boolean";
                    break;
                case "System.DateTime":
                    name = "date";
                    break;
            }
            if (prop.EnumMetadatas != null)
            {
                name = "number";
            }
            return name;
        }
    }
}