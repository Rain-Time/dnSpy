/*
    Copyright (C) 2014-2019 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using dndbg.Engine;
using dnSpy.Contracts.Debugger;
using dnSpy.Contracts.Debugger.DotNet;
using dnSpy.Debugger.DotNet.Metadata;

namespace dnSpy.Debugger.DotNet.CorDebug.Impl {
	sealed class DbgCorDebugInternalAppDomainImpl : DbgDotNetInternalAppDomain {
		public override DmdAppDomain ReflectionAppDomain { get; }
		public override DbgAppDomain AppDomain => appDomain ?? throw new InvalidOperationException();
		internal DnAppDomain DnAppDomain { get; }
		DbgAppDomain? appDomain;
		public DbgCorDebugInternalAppDomainImpl(DmdAppDomain reflectionAppDomain, DnAppDomain dnAppDomain) {
			ReflectionAppDomain = reflectionAppDomain ?? throw new ArgumentNullException(nameof(reflectionAppDomain));
			DnAppDomain = dnAppDomain ?? throw new ArgumentNullException(nameof(dnAppDomain));
		}
		internal void SetAppDomain(DbgAppDomain appDomain) {
			this.appDomain = appDomain ?? throw new ArgumentNullException(nameof(appDomain));
			ReflectionAppDomain.GetOrCreateData(() => appDomain);
		}
		protected override void CloseCore(DbgDispatcher dispatcher) { }
	}
}
