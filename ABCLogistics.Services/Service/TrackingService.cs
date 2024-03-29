﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Services.IService;
using ABCLogistics.Data;
using ABCLogistics.Data.DAO;

namespace ABCLogistics.Services.Service
{

    public class TrackingService : ITrackingService
    {

        private TrackingDAO _trackingDAO;
        public TrackingService()
        {
            _trackingDAO = new TrackingDAO();
        }

        // CREATE ===================================================================
        // addTracking
        public void addTracking(Tracking tracking)
        {
            _trackingDAO.addTracking(tracking);
        }

        // READ =====================================================================
        // getTrackinges
        public IList<Tracking> getTrackings()
        {
            return _trackingDAO.getTrackings();
        }

        // getOrderTrackings : Returns IList of Tracking of a specific order.
        public IList<Tracking> getOrderTrackings(int id)
        {
            return _trackingDAO.getOrderTrackings(id);
        }

        // getTracking
        public Tracking getTracking(int id)
        {
            return _trackingDAO.getTracking(id);
        }

        // UPDATE ===================================================================
        // editTracking
        public void editTracking(Tracking tracking)
        {
            _trackingDAO.editTracking(tracking);
        }

        // DELETE ===================================================================
        // deleteTracking
        public void deleteTracking(Tracking tracking)
        {
            _trackingDAO.deleteTracking(tracking);
        }

    }

}
