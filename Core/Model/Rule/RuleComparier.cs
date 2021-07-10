/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core.Model.Rule
{
    internal static class RuleCompariers
    {

        /// <summary>
        /// Compare fields
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="operatr"></param>
        /// <param name="rightSide"></param>
        /// <param name="rightSideType"></param>
        /// <param name="request">Base object for rule check. For example for restriction reference rule</param>
        /// <param name="app"></param>
        /// <returns></returns>
        public static bool CompareField(IUserField leftSide,
            CoaRuleComparisonsTypes operatr,
            dynamic rightSide,
            CoaRuleRightSideTypes rightSideType,
            ICustomObject request,
            IApplication app)
        {
            var result = false;
            dynamic resultRightValue = rightSide;
            if (rightSide?.ToString().Contains("LocalObject") == true)
            {
                var fieldPath = rightSide.ToString().Replace("<LocalObject>.", "");
                var fields = CoaUserFieldDefinition.GetFieldsByPath(request.CustomObjFolder, fieldPath);
                IUserField field = request.UserFields[fields[0].Alias];
                for (var i = 1; i < fields.Count; i++)
                {
                    if (field == null)
                        break;
                    field = (field.TValue as ICustomObject)?.UserFields[fields[i].Alias];
                }
                if (field != null)
                    resultRightValue = field.TValue;
                else
                    resultRightValue = null;
            }
            //TODO:dig into other branches of switch operator and replace resultRightValue for right side
            switch (leftSide.Definition.Type)
            {
                case CoaFieldTypes.AutoNumber:
                    var dt = (IAutoNumberDetailes)leftSide.Definition.Details;
                    result = CompareLongs(Convert.ToInt64(dt.ConvertStringToNumber(leftSide.TValue.ToString())), Convert.ToInt64(rightSide), operatr);
                    break;
                case CoaFieldTypes.Bigint:
                    result = CompareLongs(Convert.ToInt32(leftSide.TValue), Convert.ToInt32(rightSide), operatr);
                    break;
                case CoaFieldTypes.Int:
                    result = CompareInts(Convert.ToInt32(leftSide.TValue), Convert.ToInt32(rightSide), operatr);
                    break;
                case CoaFieldTypes.ShortInt:
                    result = CompareShorts(Convert.ToInt16(leftSide.TValue), Convert.ToInt16(rightSide), operatr);
                    break;
                case CoaFieldTypes.Boolean:
                    if (operatr == CoaRuleComparisonsTypes.EqualTo)
                        result = Convert.ToBoolean(leftSide.TValue) == Convert.ToBoolean(rightSide);
                    else
                        result = Convert.ToBoolean(leftSide.TValue) != Convert.ToBoolean(rightSide);
                    break;
                case CoaFieldTypes.Date:
                    result = CompareDates(Convert.ToDateTime(leftSide.TValue), rightSide, operatr, rightSideType);
                    break;
                case CoaFieldTypes.DropDownList:
                    {
                        if (leftSide.TValue != null)
                        {
                            switch (operatr)
                            {
                                case CoaRuleComparisonsTypes.EqualTo:
                                    return ((IDropDownValue)leftSide.TValue).Alias == ((IDropDownValue)rightSide)?.Alias;
                                case CoaRuleComparisonsTypes.NotEqualTo:
                                    return ((IDropDownValue)leftSide.TValue).Alias != ((IDropDownValue)rightSide)?.Alias;
                            }
                            if (leftSide.TValue == rightSide)
                                return true;
                        }
                        result = ((IDropDownValue)leftSide.TValue)?.Alias == ((IDropDownValue)rightSide)?.Alias;
                    }
                    break;
                case CoaFieldTypes.Object:
                    result = CompareObjects(leftSide.TValue, resultRightValue, operatr, app);
                    break;
                case CoaFieldTypes.String:
                    result = CompareStrings(leftSide.TValue?.ToString(), rightSide.ToString(), operatr);
                    break;
                case CoaFieldTypes.ObjectList:
                    result = CompareObjectList((ICustomObjects)leftSide.TValue, resultRightValue, operatr);
                    break;
                case CoaFieldTypes.Workflow:
                    result = CompareWorkflowFields(leftSide, resultRightValue, operatr);
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare numbers
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareInts(int leftValue, int rightValue,
            CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = leftValue == rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThan:
                    result = leftValue > rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThanOrEqual:
                    result = leftValue >= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThanOrEqual:
                    result = leftValue <= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThan:
                    result = leftValue < rightValue;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = leftValue != rightValue;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare shorts
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareShorts(short leftValue, short rightValue,
            CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = leftValue == rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThan:
                    result = leftValue > rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThanOrEqual:
                    result = leftValue >= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThanOrEqual:
                    result = leftValue <= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThan:
                    result = leftValue < rightValue;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = leftValue != rightValue;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare longs
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareLongs(long leftValue, long rightValue,
            CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = leftValue == rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThan:
                    result = leftValue > rightValue;
                    break;
                case CoaRuleComparisonsTypes.GreaterThanOrEqual:
                    result = leftValue >= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThanOrEqual:
                    result = leftValue <= rightValue;
                    break;
                case CoaRuleComparisonsTypes.LessThan:
                    result = leftValue < rightValue;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = leftValue != rightValue;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare dates
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="operatorType"></param>
        /// <param name="rightSideType"></param>
        /// <returns></returns>
        public static bool CompareDates(DateTime leftValue, object rightValue,
            CoaRuleComparisonsTypes operatorType, CoaRuleRightSideTypes rightSideType)
        {
            var right = new DateTime();
            var result = false;
            if (rightSideType == CoaRuleRightSideTypes.RelativeDateTime)
            {
                var current = DateTime.Now;
                switch ((CoaRuleRelativeDateTypes)rightValue)
                {
                    case CoaRuleRelativeDateTypes.CurrentTime:
                        right = current;
                        break;
                    case CoaRuleRelativeDateTypes.StartCurrentDay:
                        right = new DateTime(current.Year, current.Month, current.Day, 0, 0, 0);
                        break;
                    case CoaRuleRelativeDateTypes.StartCurrentMonth:
                        right = new DateTime(current.Year, current.Month, 1, 0, 0, 0);
                        break;
                    case CoaRuleRelativeDateTypes.StartCurrentWeek:
                        right = (new DateTime(current.Year, current.Month, current.Day)).AddDays(-(int)current.DayOfWeek);
                        break;
                    case CoaRuleRelativeDateTypes.StartCurrentYear:
                        right = new DateTime(current.Year, 1, 1, 0, 0, 0);
                        break;
                    case CoaRuleRelativeDateTypes.StartNextMonth:
                        right = (new DateTime(current.Year, current.Month, 1, 0, 0, 0)).AddMonths(1);
                        break;
                    case CoaRuleRelativeDateTypes.StartPreviousMonth:
                        right = (new DateTime(current.Year, current.Month, 1, 0, 0, 0)).AddMonths(-1);
                        break;
                    case CoaRuleRelativeDateTypes.StartNextYear:
                        right = (new DateTime(current.Year, 1, 1, 0, 0, 0)).AddYears(1);
                        break;
                    case CoaRuleRelativeDateTypes.StartPreviousYear:
                        right = (new DateTime(current.Year, 1, 1, 0, 0, 0)).AddYears(-1);
                        break;
                }
            }
            else
            {
                right = DateTime.Parse(rightValue.ToString());
            }
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = leftValue == right;
                    break;
                case CoaRuleComparisonsTypes.GreaterThan:
                    result = leftValue > right;
                    break;
                case CoaRuleComparisonsTypes.GreaterThanOrEqual:
                    result = leftValue >= right;
                    break;
                case CoaRuleComparisonsTypes.LessThanOrEqual:
                    result = leftValue <= right;
                    break;
                case CoaRuleComparisonsTypes.LessThan:
                    result = leftValue < right;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = leftValue != right;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare objects
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operatorType"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        public static bool CompareObjects(dynamic left, dynamic right, CoaRuleComparisonsTypes operatorType, IApplication app)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.ContainsCurrentUser:
                    var currUser = app.ActiveSession.ActiveUser;
                    result = (left as IUser)?.UniqueId == currUser?.UniqueId;
                    break;
                case CoaRuleComparisonsTypes.EqualTo:
                case CoaRuleComparisonsTypes.Is:
                    result = left == (right ?? left);
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                case CoaRuleComparisonsTypes.IsNot:
                    result = left != right;
                    break;
                case CoaRuleComparisonsTypes.IsUser:
                    result = left is IUser;
                    break;
                case CoaRuleComparisonsTypes.IsMemberOf:
                    {
                        if (right == null || left == null)
                        {
                            result = true;
                        }
                        else
                        {
                            var req = left as ICustomObject;
                            if (right is not ICustomObjects objects)
                            {
                                result = false;
                            }
                            else
                            {
                                var requests = objects;
                                result = false;
                                for (var i = 0; i < requests.Count; i++)//TODO: perfomance issue.
                                    if (requests[i].UniqueId == req.UniqueId)
                                    {
                                        result = true;
                                    }
                            }
                        }
                    }
                    break;
                case CoaRuleComparisonsTypes.IsNotMemberOf:
                    {
                        if (right == null || left == null)
                        {
                            result = true;
                        }
                        else
                        {
                            var req = left as ICustomObject;
                            if (!(right is ICustomObjects objects))
                            {
                                result = false;
                            }
                            else
                            {
                                var requests = objects;
                                result = true;
                                for (var i = 0; i < requests.Count; i++)//TODO: perfomance issue.
                                    if (requests[i].UniqueId == req.UniqueId)
                                    {
                                        result = false;
                                        break;
                                    }
                            }
                        }
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare two lists of object, in right side constants
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareObjectList(ICustomObjects left, object right, CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.Contains:
                    {
                        if (right == null || left == null)
                            return true;
                        var request = (ICustomObject)right;
                        if (request == null)
                            return false;
                        for (var i = 0; i < left.Count; i++)
                            if (left[i].UniqueId == request.UniqueId)
                            {
                                result = true;
                                break;
                            }
                    }
                    break;
                case CoaRuleComparisonsTypes.NotContains:
                    {
                        if (right == null || left == null)
                            return true;
                        var request = (ICustomObject)right;
                        if (request == null)
                            return false;
                        result = true;
                        for (var i = 0; i < left.Count; i++)
                            if (left[i].UniqueId == request.UniqueId)
                            {
                                result = false;
                                break;
                            }
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare strings
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareStrings(string left, string right, CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = string.CompareOrdinal(left, right) == 0;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = string.CompareOrdinal(left, right) != 0;
                    break;
                case CoaRuleComparisonsTypes.GreaterThan:
                    result = string.CompareOrdinal(left, right) == 1;
                    break;
                case CoaRuleComparisonsTypes.GreaterThanOrEqual:
                    result = string.CompareOrdinal(left, right) >= 0;
                    break;
                case CoaRuleComparisonsTypes.LessThan:
                    result = string.CompareOrdinal(left, right) == -1;
                    break;
                case CoaRuleComparisonsTypes.LessThanOrEqual:
                    result = string.CompareOrdinal(left, right) <= 0;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare current user
        /// </summary>
        /// <param name="right"></param>
        /// <param name="operatorType"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        public static bool CompareCurrentUser(object right, CoaRuleComparisonsTypes operatorType, IApplication app)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.BelongsToGroup:
                    break;
                case CoaRuleComparisonsTypes.DoesNotBelongToGroup:
                    break;
                case CoaRuleComparisonsTypes.Is:
                    {
                        var req = (ICustomObject)right;
                        var currUser = app.ActiveSession.ActiveUser.Object;
                        result = req.UniqueId == currUser.UniqueId;
                    }
                    break;
                case CoaRuleComparisonsTypes.IsNot:
                    {
                        var req = (ICustomObject)right;
                        var currUser = app.ActiveSession.ActiveUser.Object;
                        result = req.UniqueId != currUser.UniqueId;
                    }
                    break;
                case CoaRuleComparisonsTypes.IsInternalUser:
                    break;
                case CoaRuleComparisonsTypes.IsSuperuser:
                    break;
            }
            return result;
        }
        /// <summary>
        /// Compare workflow fields
        /// </summary>
        /// <param name="field">Field value</param>
        /// <param name="right">Field or constant</param>
        /// <param name="operatorType">Comparison operator</param>
        /// <returns></returns>
        public static bool CompareWorkflowFields(IUserField field, object right, CoaRuleComparisonsTypes operatorType)
        {
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    return field.TValue?.ToString() == right?.ToString();
                case CoaRuleComparisonsTypes.NotEqualTo:
                    return field.TValue?.ToString() != right?.ToString();
                case CoaRuleComparisonsTypes.IsInitialState:
                    {
                        var det = field.Definition.Details as IWorkflowDetails;
                        for (var i = 0; i < det.States.Count; i++)
                            if (det.States[i].Initial && det.States[i].Code == right.ToString())
                                return true;
                    }
                    break;
                case CoaRuleComparisonsTypes.IsNotInitialState:
                    {
                        var det = field.Definition.Details as IWorkflowDetails;
                        for (var i = 0; i < det.States.Count; i++)
                            if (det.States[i].Initial && det.States[i].Code == right.ToString())
                                return false;
                        return true;
                    }
            }
            return false;
        }
        /// <summary>
        /// Compare folders
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        public static bool CompareFolder(ICustomFolder left, ICustomFolder right,
            CoaRuleComparisonsTypes operatorType)
        {
            var result = false;
            switch (operatorType)
            {
                case CoaRuleComparisonsTypes.EqualTo:
                    result = left.UniqueId == right.UniqueId;
                    break;
                case CoaRuleComparisonsTypes.NotEqualTo:
                    result = left.UniqueId != right.UniqueId;
                    break;
            }
            return result;
        }
    }
}
