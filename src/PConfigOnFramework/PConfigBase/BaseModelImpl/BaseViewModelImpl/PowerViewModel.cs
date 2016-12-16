using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class PowerViewModel : BasicModel, IViewModel
    {
        private float enableProbe;

        public float EnableProbe
        {
            get { return enableProbe; }
            set { enableProbe = value; }
        }
        private float enableProbe_low;

        public float EnableProbe_low
        {
            get { return enableProbe_low; }
            set { enableProbe_low = value; }
        }
        private float enableProbe_high;

        public float EnableProbe_high
        {
            get { return enableProbe_high; }
            set { enableProbe_high = value; }
        }
        private float disableProbe;

        public float DisableProbe
        {
            get { return disableProbe; }
            set { disableProbe = value; }
        }
        private float disableProbe_low;

        public float DisableProbe_low
        {
            get { return disableProbe_low; }
            set { disableProbe_low = value; }
        }
        private float disableProbe_high;

        public float DisableProbe_high
        {
            get { return disableProbe_high; }
            set { disableProbe_high = value; }
        }
        private float disableTelecom;

        public float DisableTelecom
        {
            get { return disableTelecom; }
            set { disableTelecom = value; }
        }
        private float disableTelecom_low;

        public float DisableTelecom_low
        {
            get { return disableTelecom_low; }
            set { disableTelecom_low = value; }
        }
        private float disableTelecom_high;

        public float DisableTelecom_high
        {
            get { return disableTelecom_high; }
            set { disableTelecom_high = value; }
        }
        private float supply;

        public float Supply
        {
            get { return supply; }
            set { supply = value; }
        }
        private float battery;

        public float Battery
        {
            get { return battery; }
            set { battery = value; }
        }
        private float solar;

        public float Solar
        {
            get { return solar; }
            set { solar = value; }
        }
        private float solarCharge;

        public float SolarCharge
        {
            get { return solarCharge; }
            set { solarCharge = value; }
        }
    }
}
