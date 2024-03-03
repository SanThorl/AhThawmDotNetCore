const tblBlog = 'Tbl_Blog';
let _blogId = '';
runBlog();

function runBlog() {
    readBlog();
    //     //createBlog('title', 'author', 'content');
    //     //editBlog('686a110c-e566-451f-9a82-4c595b861e3f');
    //      //editBlog('45');
    //     // const id=prompt("Enter ID");
    //     // const title=prompt("Enter Title");
    //     // const author=prompt("Enter Author");
    //     // const content=prompt("Enter Content");
    //     // updateBlog(id,title,author,content);
    //     //deleteBlog('38b65ec6-e2b0-4865-a6eb-86632626786f');
    //     //deleteBlog('23');
}

function readBlog() {
    $('#tbDataTable').html('');
    let lstBlog = getBlogs();
    let htmlRow = '';
    for (let i = 0; i < lstBlog.length; i++) {
        const item = lstBlog[i];
        // console.log(item.Title);
        // console.log(item.Author);
        // console.log(item.Content);
        htmlRow += `<tr>
                    <td>
                        <button type="button" class="btn btn-warning" onclick="editBlog('${item.Id}')">Edit</button>
                        <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.Id}')">Delete</button>
                    </td>
                    <th scope = "row" > ${i + 1}</th >
                    <td>${item.Title}</td>
                    <td>${item.Author}</td>
                    <td>${item.Content}</td>
                    </tr>
                    `
    }
    console.log(htmlRow);
    $('#tbDataTable').html(htmlRow);
}

function editBlog(id) {
    let lstBlog = getBlogs();
    let lst = lstBlog.filter(X => X.Id === id);

    if (lst.length === 0) {
        console.log("No Data Found.");
        return;
    }
    let item = lst[0];
    console.log(item);
    $('#Title').val(item.Title);
    $(' #Author').val(item.Author);
    $('#Content').val(item.Content);
    _blogId = item.Id;
}

function createBlog(title, author, content) {
    let lstBlog = getBlogs();
    const blog = {
        Id: uuidv4(),
        Title: title,
        Author: author,
        Content: content
    }
    lstBlog.push(blog);
    setLocalStorage(lstBlog);
}

function updateBlog(id, title, author, content) {
    let lstBlog = getBlogs();

    let lst = lstBlog.filter(X => X.Id === id);
    if (lst.length === 0) {
        console.log("No Data Found.");
        return;
    }
    let index = lstBlog.findIndex(X => X.Id === id);
    lstBlog[index] = {
        Id: id,
        Title: title,
        Author: author,
        Content: content
    }
    setLocalStorage(lstBlog);
}

function deleteBlog(id) {
    let result = confirm('Are you sure want to delete?');
    if (!result) return;

    let lstBlog = getBlogs();

    let lst = lstBlog.filter(X => X.Id === id);
    if (lst.length === 0) {
        console.log("No Data Found.");
        return;
    }
    lstBlog = lstBlog.filter(X => X.Id !== id);

    setLocalStorage(lstBlog);

    readBlog();
}
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

function getBlogs() {
    let lstBlogs = [];
    let blogStr = localStorage.getItem(tblBlog);
    if (blogStr != null) {
        lstBlogs = JSON.parse(blogStr);
    }
    return lstBlogs;
}

function setLocalStorage(blogs) {
    let jsonStr = JSON.stringify(blogs);
    localStorage.setItem(tblBlog, jsonStr);
}

$('#btnSave').click(function () {
    const title = $('#Title').val();
    const author = $('#Author').val();
    const content = $('#Content').val();
    if (_blogId === '') {
        createBlog(title, author, content);
        alert('Saving Successful.');
    }
    else {
        updateBlog(_blogId, title, author, content);
        alert('Updating Successful.');
        _blogId = '';
    }
    $('#Title').val('');
    $('#Author').val('');
    $('#Content').val('');
    $('#Title').focus();
    readBlog();
})
