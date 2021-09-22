import http from './httpCommon';

class MovieService {
    getAll(filterTile, filterGenre, filterActor, page) {
        return http.get(`/Movies?filterTile=${filterTile}, filterGenre=${filterGenre}, filterActor=${filterActor}, page=${page}`);
    }
}

export default new MovieService();