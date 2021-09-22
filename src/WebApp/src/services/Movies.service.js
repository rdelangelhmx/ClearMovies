import http from './httpCommon';

class MovieService {
    GetAll(filterTile, filterGenre, filterActor, page) {
        if(!filterTile || filterTile === '') filterTile = null;
        if(!filterGenre || filterGenre === '') filterGenre = null;
        if(!filterActor || filterActor === '') filterActor = null;
        if(!page) page = 1;
        return http.get(`/Movies/GetAll?filterTile=${filterTile}, filterGenre=${filterGenre}, filterActor=${filterActor}, page=${page}`);
    }
}

export default new MovieService();