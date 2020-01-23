import React, { useState, useEffect } from 'react';
import './coordinates.css';

const GetCoordinates = () => {
  return ( 
    <div className="getcoordinates_parent_container">
      <div className={`bd-callout bd-callout-info getcoordinates_summary_text`} >
        Enter the triangle coordinates for get the vertices for the given triangle:
      </div>
      <div className="input-group ">
        <div className="input-group-prepend">
          <span className="input-group-text">Row and Column</span>
        </div>
        <input type="text" aria-label="Row" class="form-control" placeholder="Row (A-F)" />
        <input type="text" aria-label="Column" class="form-control" placeholder="Column (1-12)" />
      </div>
      <button type="button" className="btn btn-primary btn-lg getcoordinates_button">
          Get Vertices
      </button>
      <div className="alert alert-info getcoordinates_results" >
        Results go here
      </div>
    </div>
   );
}
 
export default GetCoordinates;