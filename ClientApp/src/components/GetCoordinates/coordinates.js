import React, { useState, useEffect } from 'react';
import './coordinates.css';

const GetCoordinates = () => {
  const [coordinates, setCoordinates] = useState('');
  const [isFetching, setIsFetching] = useState(false);
  const [row, setRow] = useState('A');
  const [column, setColumn] = useState(1);

  useEffect(() => {
    if(!isFetching) return;
    
    const fetchCoordinates = async () => {
      const resp = await fetch(`api/triangles/${row}/${column}`, {
        method: 'GET'
      });
      const data = await resp.json();

      console.log(data);
      setCoordinates(JSON.stringify(data, null, 2));
      setIsFetching(false);
    };
    fetchCoordinates()
  }, [isFetching, column, setColumn])

  const onRowChange = event => {
    const newRow = event.target.value;
    setRow(newRow);
  }

  const onColumnChange = event => {
    const newCol = event.target.value;
    setColumn(newCol);
  }

  const onGetVertices = () => {
    if(!isFetching)
      setIsFetching(true);
  }
  return ( 
    <div className="getcoordinates_parent_container">
      <div className={`bd-callout bd-callout-info getcoordinates_summary_text`} >
        Enter the triangle coordinates for get the vertices for the given triangle:
      </div>
      <div className="input-group ">
        <div className="input-group-prepend">
          <span className="input-group-text">Row and Column</span>
        </div>
        <input type="text" aria-label="Row" className="form-control" 
          placeholder="Row (A-F)" 
          onChange={onRowChange} 
          value={row} />
        <input type="text" aria-label="Column" className="form-control" 
          placeholder="Column (1-12)"
          onChange={e => setColumn(e.target.value)}
          value={column} />
      </div>
      <button type="button" className={`btn btn-primary btn-lg getcoordinates_button ${isFetching ? 'disabled' : ''}`}
        onClick={onGetVertices}>
          {isFetching ? 'Getting vertices...' : 'Get Vertices'}
      </button>
      {coordinates.length > 0 &&
        <pre className="getcoordinates_results_success">
          <code className="getcoordinates_results_code">
            {coordinates}
          </code>
        </pre>
      }
    </div>
   );
}
 
export default GetCoordinates;