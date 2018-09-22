DROP TABLE IF EXISTS data;
DROP TABLE IF EXISTS recommend;


CREATE TABLE data (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    e_id INTEGER NOT NULL,
    e_category VARCHAR(255) NOT NULL,
    watch_start TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    watch_end TIMESTAMP
);

CREATE TABLE recommend (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    data TEXT NOT NULL
);
