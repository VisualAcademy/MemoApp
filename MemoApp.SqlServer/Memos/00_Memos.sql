--[1] Table: Memos(완성형 게시판) 테이블
--[!] 게시판 테이블 설계: Articles, Notes, Memos, (Basic+Upload+Reply) => DotNetMemo
CREATE TABLE [dbo].[Memos]
(
	[Id]            INT NOT NULL PRIMARY KEY Identity(1, 1),    -- [일련번호], Serial Number
	[ParentId]      Int Null,								    -- ParentId, AppId, SiteId, ...
	[ParentKey]     NVarChar(255) Null,						    -- ParentKey == 부모의 GUID

	[CreatedBy]     NVarChar(255) Null,						    -- 등록자(Creator)
	[Created]       DateTime Default(GetDate()) Null,  		    -- [생성일](PostDate), DatePublished, CreatedAt
	[ModifiedBy]    NVarChar(255) Null,					        -- 수정자(LastModifiedBy)
	[Modified]      DateTime Null,							    -- 수정일(LastModified)

    --[0] 5W1H: 누가, 언제, 어디서, 무엇을, 어떻게, 왜
    Name            NVarChar(25) Not Null,                      -- [이름](작성자)
    PostDate        DateTime Default GetDate() Not Null,        -- 작성일 
    PostIp          NVarChar(15) Null,                          -- 작성IP
    Title           NVarChar(150) Not Null,                     -- [제목]
    Content         NVarChar(Max) Not Null,                     -- [내용]
    Category        NVarChar(20) Default('Free') Null,          -- 카테고리(확장...) => '공지', '자유', '자료', '사진', ...

	--[1] 기본형 게시판 관련 주요 컬럼
    Email           NVarChar(100) Null,                         -- 이메일 
    Password        NVarChar(255) Null,                         -- 비밀번호
    ReadCount       Int Default 0,                              -- 조회수
    Encoding        NVarChar(20) Not Null,                      -- 인코딩(HTML/Text/Mixed)
    Homepage        NVarChar(100) Null,                         -- 홈페이지
    ModifyDate      DateTime Null,                              -- 수정일 
    ModifyIp        NVarChar(15) Null,                          -- 수정IP
    CommentCount    Int Default 0,                              -- 댓글수
	IsPinned        Bit Default 0 Null,                         -- 공지글로 올리기, IsActive 

	--[2] 자료실 게시판 관련 주요 컬럼
    FileName        NVarChar(255) Null,                         -- 파일명
    FileSize        Int Default 0,                              -- 파일크기
    DownCount       Int Default 0,                              -- 다운수 

	--[3] 답변형 게시판 관련 주요 컬럼
    Ref             Int Not Null,                               -- 참조(부모글)
    Step            Int Not Null Default 0,                     -- 답변깊이(레벨)
    RefOrder        Int Not Null Default 0,                     -- 답변순서
    AnswerNum       Int Not Null Default 0,                     -- 답변수
    ParentNum       Int Not Null Default 0,                     -- 부모글번호
)
Go
