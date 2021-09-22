import React, { Component } from 'react';
import MoviesService from '../services/Movies.service';

export class Movies extends Movies {
  static displayName = Movies.name;

  constructor(props) {
    super(props);
    this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
    this.onChangeSearchGenre = this.onChangeSearchGenre.bind(this);
    this.onChangeSearchActor = this.onChangeSearchActor.bind(this);

    this.populateMoviesData = this.populateMoviesData.bind(this);
    this.refreshList = this.refreshList.bind(this);

    this.searchTitle = this.searchTitle.bind(this);
    this.searchGenre = this.searchGenre.bind(this);
    this.searchActor = this.searchActor.bind(this);
    
    this.state = { 
      movies: [], 
      currentIndex: 1,
      searchTitle: "",      
      searchGenre: "",      
      searchActor: "",      
      loading: true };
  }

  componentDidMount() {
    this.populateMoviesData();
  }

  onChangeSearchTitle(e) {
    const searchTitle = e.target.value;

    this.setState({
      searchTitle: searchTitle
    });
  }  

  onChangeSearchGenre(e) {
    const searchGenre = e.target.value;

    this.setState({
      searchGenre: searchGenre
    });
  }

  onChangeSearchActor(e) {
    const searchActor = e.target.value;

    this.setState({
      searchActor: searchActor
    });
  }

  static renderMoviesTable(movies) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Home Page</th>
            <th>Release Date</th>
            <th>Revenue</th>
          </tr>
        </thead>
        <tbody>
          {movies.map(movie =>
            <tr key={movie.movie_id}>
              <td>{movie.title}</td>
              <td>{movie.homepage}</td>
              <td>{movie.release_date}</td>
              <td>{movie.revenue}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  async populateMoviesData() {
    MoviesService.GetAll()
    .then(response => {
      console.log(response);
      this.setState({ movies: response.data, loading: false });
    })
    .catch(err => {
      console.log(err);
    });    
  }

  refreshList() {
    this.populateMoviesData();
    this.setState({
      currentIndex: 1
    });
  }

  searchMovies() {
    MoviesService.getAll(this.filterTitle, this.filterGenre, this.filterActor, this.currentIndex)
      .then(response => {
        this.setState({
          movies: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Movies.renderMoviesTable(this.state.movies);

    return (
      <div>
        <h1 id="tabelLabel" >Movies</h1>
        <div class="form-inline">
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              placeholder="Search by title"
              value={searchTitle}
              onBlur={this.onChangeSearchTitle} />
          </div>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              placeholder="Search by genre"
              value={searchGenre} 
              onBlur={this.onChangeSearchGenre} />
          </div>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              placeholder="Search by actor"
              value={searchActor}
              onBlur={this.onChangeSearchActor} />
          </div>
          <button
            className="btn btn-primary mb-2"
            type="button"
            onClick={this.searchTitle}>Search</button>
        </div>
        <div className="list row">
          {contents}
        </div>
    </div>
    );
  }
}
