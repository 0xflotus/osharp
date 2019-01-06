// -----------------------------------------------------------------------
//  <copyright file="EntityMetadata.cs" company="OSharp��Դ�Ŷ�">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>������</last-editor>
//  <last-date>2018-08-06 12:25</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;


namespace OSharp.CodeGeneration.Schema
{
    /// <summary>
    /// ʵ��Ԫ����
    /// </summary>
    public class EntityMetadata
    {
        /// <summary>
        /// ��ȡ������ ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������ ����ȫ��
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// ��ȡ������ �����ռ�
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// ��ȡ������ ������ʾ����
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// ��ȡ������ ����ģ����Ϣ
        /// </summary>
        public ModuleMetadata Module { get; set; }

        /// <summary>
        /// ��ȡ������ ʵ������Ԫ���ݼ���
        /// </summary>
        public ICollection<PropertyMetadata> PropertyMetadatas { get; set; } = new List<PropertyMetadata>();
    }
}