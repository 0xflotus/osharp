using System;
using System.Security.Authentication.ExtendedProtection;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using OSharp.Demo.Identity;
using OSharp.Demo.Identity.Entities;
using OSharp.Entity;
using OSharp.Reflection;

using Xunit;


namespace OSharp.Demo.Core.Tests
{
    public class IdentityTests
    {
        [Fact]
        public void StartupTest()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddOSharp();
            services.Replace(ServiceDescriptor.Scoped<IUnitOfWork, TestUnitOfWork>());
            services.AddIdentity<User, Role>();
            services.AddLogging();
            services.AddScoped<IUserStore<User>, UserStore>();

            IServiceProvider provider = services.BuildServiceProvider();
            UserManager<User> userManager = provider.GetService<UserManager<User>>();
            Assert.NotNull(userManager);
        }
        
        private class TestUnitOfWork : IUnitOfWork
        {
            #region Implementation of IDisposable

            /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
            public void Dispose()
            { }

            #endregion

            #region Implementation of IUnitOfWork

            /// <summary>
            /// ��ȡָ����������������<typeparamref name="TEntity"/>��ʵ��
            /// </summary>
            /// <typeparam name="TEntity">ʵ������</typeparam>
            /// <typeparam name="TKey">ʵ����������</typeparam>
            /// <returns><typeparamref name="TEntity"/>�������������ʵ��</returns>
            public IDbContext GetDbContext<TEntity, TKey>() where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
            {
                return new TestDbContext();
            }

            /// <summary>
            /// �ύ��ǰ�����ĵ��������
            /// </summary>
            public void Commit()
            { }

            #endregion
        }


        private class TestDbContext : DbContext, IDbContext
        { }
    }
}