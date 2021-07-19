﻿using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public class Region : GoogleEarthObject, IRegion
    {
        private bool _notChangedSinceInitialisation = true;
        
        private ILatLonAltBox _latLonAltBox;
        public ILatLonAltBox LatLonAltBox
        {
            get => _latLonAltBox;
            set 
            { 
                _latLonAltBox = value;
                _notChangedSinceInitialisation = false;
            }
        }

        private ILod lod;
        public ILod Lod
        {
            get => lod;
            set 
            { 
                lod = value;
                _notChangedSinceInitialisation = false;
            }
        }

        public Region()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            LatLonAltBox = new LatLonAltBox();
            Lod = new Lod();

            _notChangedSinceInitialisation = true;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Region) && Equals((Region)obj);
        }

        protected bool Equals(Region other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(LatLonAltBox, other.LatLonAltBox) &&
                   Equals(Lod, other.Lod);
        }

        public static bool operator ==(Region a, Region b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Region a, Region b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            if (_notChangedSinceInitialisation)
                return string.Empty;
            
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(LatLonAltBox.ConvertObjectToKML());
            sw.Write(Lod.ConvertObjectToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
