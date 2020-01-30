import React, { useState, useEffect } from 'react';
import Results from '../Results';
import './vertices.css';

const GetVertices = () => {
  const [topLeftX, setTopLeftX] = useState(30);
  const [topLeftY, setTopLeftY] = useState(40);
  const [midX, setMidX] = useState(30);
  const [midY, setMidY] = useState(30);
  const [bottomRightX, setbottomRightX] = useState(40);
  const [bottomRightY, setbottomRightY] = useState(30);

  const [isFetching, setIsFetching] = useState(false);
  const [coordinate, setCoordinate] = useState(0);

  useEffect(() => {
    if(!isFetching) return;
    
    const fetchCoordinates = async () => {
      const query = `TopLeftX=${topLeftX}&TopLefty=${topLeftY}&Middley=${midY}&middlex=${midX}&BottomRighty=${bottomRightY}&bottomrightx=${bottomRightX}`
      const resp = await fetch(`api/triangles/coordinates?${query}`, {
        method: 'GET'
      });
      const data = await resp.json();

      setCoordinate(JSON.stringify(data, null, 2));
      setIsFetching(false);
    };
    fetchCoordinates()
  }, [isFetching, topLeftX, topLeftY, midX, midY, bottomRightX, bottomRightY])


  const onGetVertices = () => {
    if(!isFetching)
      setIsFetching(true);
  }

  return ( 
    <div className="getcoordinates_parent_container">
      <div className={`bd-callout bd-callout-info getcoordinates_summary_text`} >
        Enter the vertices to get the corresponding triangle coordinate:
      </div>
      <div className="input-group ">
        <div className="input-group-prepend">
          <span className="input-group-text">Top Left X and Top Left Y</span>
        </div>
        <input type="text" aria-label="Row" className="form-control" 
          placeholder="X (0-60)"
          onChange={e => setTopLeftX(e.target.value)} 
          value={topLeftX} />
        <input type="text" aria-label="Column" className="form-control"
          placeholder="Y (0-60)" 
          onChange={e => setTopLeftY(e.target.value)}
          value={topLeftY} />
      </div>
      <div className="input-group ">
        <div className="input-group-prepend">
          <span className="input-group-text">Bottom Right X and Bottom Right Y</span>
        </div>
        <input type="text" aria-label="Row" className="form-control" 
          placeholder="X (0-60)"
          onChange={e => setbottomRightX(e.target.value)} 
          value={bottomRightX} />
        <input type="text" aria-label="Column" className="form-control" 
          placeholder="Y (0-60)" 
          onChange={e => setbottomRightY(e.target.value)}
          value={bottomRightY} />
      </div>
      <div className="input-group ">
        <div className="input-group-prepend">
          <span className="input-group-text">Middle X and Middle Y</span>
        </div>
        <input type="text" aria-label="Row" className="form-control" 
          placeholder="X (0-60)"
          onChange={e => setMidX(e.target.value)} 
          value={midX} />
        <input type="text" aria-label="Column" className="form-control" 
          placeholder="Y (0-60)" 
          onChange={e => setMidY(e.target.value)}
          value={midY} />
      </div>
      <button type="button" className={`btn btn-primary btn-lg getcoordinates_button ${isFetching ? 'disabled' : ''}`}
        onClick={onGetVertices}>
          {isFetching ? 'Getting coordinate...' : 'Get Coordinate'}
      </button>
      <Results results={coordinate} />
    </div>
   );
}
 
export default GetVertices;