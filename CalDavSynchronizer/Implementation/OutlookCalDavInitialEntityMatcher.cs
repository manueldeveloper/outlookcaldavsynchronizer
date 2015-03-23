﻿// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer 
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using CalDavSynchronizer.Generic.InitialEntityMatching;
using DDay.iCal;
using Microsoft.Office.Interop.Outlook;

namespace CalDavSynchronizer.Implementation
{
  internal class OutlookCalDavInitialEntityMatcher : InitialEntityMatcherByPropertyGrouping<AppointmentItem, string, DateTime, string, IEvent, Uri, string, string>
  {
    
    protected override bool AreEqual (AppointmentItem atypeEntity, IEvent btypeEntity)
    {
      return
          btypeEntity.Summary == atypeEntity.Subject &&
          (btypeEntity.IsAllDay && atypeEntity.AllDayEvent ||
           btypeEntity.Start.UTC == atypeEntity.StartUTC.ToUniversalTime() &&
           btypeEntity.DTEnd.UTC == atypeEntity.EndUTC.ToUniversalTime());
    }

    protected override string GetAtypePropertyValue (AppointmentItem atypeEntity)
    {
      return atypeEntity.Subject.ToLower();
    }

    protected override string GetBtypePropertyValue (IEvent btypeEntity)
    {
      return btypeEntity.Summary.ToLower();
    }

    protected override string MapAtypePropertyValue (string value)
    {
      return value;
    }

  }
}