import React, { Component } from 'react';
import MoviesService from '../services/Movies.service';

export class Movies extends Component {
  static displayName = Movies.name;

  constructor(props) {
    super(props);
    this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
    this.onChangeSearchGenre = this.onChangeSearchGenre.bind(this);
    this.onChangeSearchActor = this.onChangeSearchActor.bind(this);

    this.populateMoviesData = this.populateMoviesData.bind(this);
    this.refreshList = this.refreshList.bind(this);

    this.state = { 
      movies: [], 
      currentPage: 1,
      size: 0,
      pages: 0,
      records: 0,
      searchTitle: "",      
      searchGenre: "",      
      searchActor: "",      
      loading: true };
  }

  componentDidMount() {
    this.populateMoviesData();
  }

  onChangeSearchTitle(e) {
    this.setState({
      searchTitle: e.target.value
    });
  }  

  onChangeSearchGenre(e) {
    this.setState({
      searchGenre: e.target.value
    });
  }

  onChangeSearchActor(e) {
    this.setState({
      searchActor: e.target.value
    });
  }

  static renderMoviesTable(data) {
    let pagination = this.state.loading
    ? <p><em>Loading...</em></p>
    : Movies.pagination(this.state);

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
          {data.Movies.map(movie =>
            <tr key={movie.movie_id}>
              <td>{movie.title}</td>
              <td>{movie.homepage}</td>
              <td>{movie.release_date}</td>
              <td>{movie.revenue}</td>
            </tr>
          )}
        </tbody>
        <tfoot>
          <tr>
            <td colSpan="4">
              {pagination}
            </td>
          </tr>
        </tfoot>
      </table>
    );
  }

  static pagination(data)
  {
    let items = {};
    for (let number = 1; number <= 5; number++) {
      if(number == data.currentPage)
      items.push(
        <li class="page-item"><a class="page-link" href="#">number</a></li>
      );
      else 
      items.push(
        <li class="page-item"><a class="page-link" href="#">number</a></li>
      );
    }
    
    const paginationBasic = (
      <nav aria-label="Page navigation example">
        <ul class="pagination justify-content-center">
          <li class="page-item disabled">
            <a class="page-link" href="#" tabindex="-1">Previous</a>
          </li>
          {items}
          <li class="page-item">
            <a class="page-link" href="#">Next</a>
          </li>
        </ul>
      </nav>
    );

    return(paginationBasic);
  }

  async populateMoviesData() {
    MoviesService.GetAll(this.state.searchTitle, this.state.searchGenre, this.state.searchActor, this.state.currentPage)
    .then(response => {
      console.log(response.data.Items);
      console.log(response.data.Count);
      this.setState({ 
        movies: response.data.Items, 
        count: response.data.Count,
        size: response.data.Size,
        pages: response.data.Pages,
        loading: false });
    })
    .catch(err => {
      console.log(err);
    });    
  }

  refreshList() {
    this.populateMoviesData();
    this.setState({
      currentPage: 1
    });
  }

  searchMovies() {
    MoviesService.getAll(this.filterTitle, this.filterGenre, this.filterActor, this.currentPage)
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
      : Movies.renderMoviesTable(this.state);

    return (
      <div>
        <h1 id="tabelLabel" >Movies</h1>
        <div class="form-inline">
          <div className="form-group col-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search by title"
              value={this.state.searchTitle}
              onBlur={this.onChangeSearchTitle} />
          </div>
          <div className="form-group col-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search by genre"
              value={this.state.searchGenre} 
              onBlur={this.onChangeSearchGenre} />
          </div>
          <div className="form-group col-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search by actor"
              value={this.state.searchActor}
              onBlur={this.onChangeSearchActor} />
          </div>
          <div class="col-3">
            <button
              className="btn btn-primary mb-2"
              type="button"
              onClick={this.searchTitle}>Search</button>
          </div>
        </div>
        <div className="list row">
          {contents}
        </div>
        <div className="row">
          {Movies.pagination}
        </div>
    </div>
    );
  }
}
